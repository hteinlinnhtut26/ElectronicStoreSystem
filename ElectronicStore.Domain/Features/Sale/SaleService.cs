using ElectronicStore.Database.AppDbContextModels;
using ElectronicStore.Domain.Models.Sale;
using ElectronicStore.Domain.Models.Product;

namespace ElectronicStore.Domain.Features.Sale;

public class SaleService
{
    private readonly AppDbContext _db;

    public SaleService()
    {
        _db = new AppDbContext();
    }

    public SaleCreateResponseModel CreateSale(
        SaleCreateRequestModel request)
    {
        if (request.Items == null || request.Items.Count == 0)
        {
            return new SaleCreateResponseModel
            {
                IsSuccess = false,
                Message = "Sale item not found။"
            };
        }

        var sale = new Database.AppDbContextModels.Sale
        {
            VoucherNo = GenerateVoucherNo(),
            SaleDate = DateTime.Now,
            PaidAmount = request.PaidAmount
        };

        decimal totalAmount = 0;

        foreach (var item in request.Items)
        {
            var product = _db.Products
                .FirstOrDefault(x => x.ProductId == item.ProductId);

            if (product == null)
            {
                return new SaleCreateResponseModel
                {
                    IsSuccess = false,
                    Message = $"Product Id {item.ProductId} not found."
                };
            }

            if (item.Quantity <= 0)
            {
                return new SaleCreateResponseModel
                {
                    IsSuccess = false,
                    Message = "In Valid data for quantity."
                };
            }

            if (product.StockQuantity < item.Quantity)
            {
                return new SaleCreateResponseModel
                {
                    IsSuccess = false,
                    Message =
                        $"{product.ProductName} low stock " +
                        $"Instock product: {product.StockQuantity}"
                };
            }

            decimal lineTotal = product.Price * item.Quantity;

            var saleDetail = new SaleDetail
            {
                ProductId = product.ProductId,
                Quantity = item.Quantity,
                UnitPrice = product.Price,
                LineTotal = lineTotal
            };

            sale.SaleDetails.Add(saleDetail);

            product.StockQuantity -= item.Quantity;

            totalAmount += lineTotal;
        }

        if (request.PaidAmount < totalAmount)
        {
            return new SaleCreateResponseModel
            {
                IsSuccess = false,
                Message =
                    $"Paid amount not enough." +
                    $"Total amount: {totalAmount:N0}"
            };
        }

        sale.TotalAmount = totalAmount;
        sale.ChangeAmount = request.PaidAmount - totalAmount;

        _db.Sales.Add(sale);
        _db.SaveChanges();

        return new SaleCreateResponseModel
        {
            IsSuccess = true,
            Message = "Sale created successfully.",
            SaleId = sale.SaleId,
            VoucherNo = sale.VoucherNo,
            TotalAmount = sale.TotalAmount,
            PaidAmount = sale.PaidAmount,
            ChangeAmount = sale.ChangeAmount
        };
    }

    public SaleListResponseModel GetSales(
    SaleListRequestModel request)
    {
        var sales = _db.Sales
            .OrderByDescending(x => x.SaleId)
            .Select(x => new SaleListItemModel
            {
                SaleId = x.SaleId,
                VoucherNo = x.VoucherNo,
                SaleDate = x.SaleDate,
                TotalAmount = x.TotalAmount,
                PaidAmount = x.PaidAmount,
                ChangeAmount = x.ChangeAmount
            })
            .ToList();

        if (sales.Count == 0)
        {
            return new SaleListResponseModel
            {
                IsSuccess = false,
                Message = "Sale data not found."
            };
        }

        return new SaleListResponseModel
        {
            IsSuccess = true,
            Message = "Sale list retrieved successfully.",
            Sales = sales
        };
    }

    public SaleByIdResponseModel GetSaleById(
    SaleByIdRequestModel request)
    {
        var sale = _db.Sales
            .Where(x => x.SaleId == request.SaleId)
            .Select(x => new SaleByIdResponseModel
            {
                IsSuccess = true,
                Message = "Sale data found.",
                SaleId = x.SaleId,
                VoucherNo = x.VoucherNo,
                SaleDate = x.SaleDate,
                TotalAmount = x.TotalAmount,
                PaidAmount = x.PaidAmount,
                ChangeAmount = x.ChangeAmount,

                Items = x.SaleDetails
                    .Select(d => new SaleByIdItemModel
                    {
                        ProductId = d.ProductId,
                        ProductName = d.Product.ProductName,
                        Quantity = d.Quantity,
                        UnitPrice = d.UnitPrice,
                        LineTotal = d.LineTotal
                    })
                    .ToList()
            })
            .FirstOrDefault();

        if (sale == null)
        {
            return new SaleByIdResponseModel
            {
                IsSuccess = false,
                Message = "Sale not found."
            };
        }

        return sale;
    }

    private string GenerateVoucherNo()
    {
        return $"V-{DateTime.Now:yyyyMMddHHmmssfff}";
    }

    public SaleSearchResponseModel SearchSale(
    SaleSearchRequestModel model)
    {
        string keyWord = model.KeyWord.Trim();

        var sales = _db.Sales
            .Where(x =>
                (
                    string.IsNullOrWhiteSpace(keyWord) ||
                    x.VoucherNo.Contains(keyWord)
                )
                &&
                (
                    !model.SaleDate.HasValue ||
                    x.SaleDate.Date == model.SaleDate.Value.Date
                ))
            .OrderByDescending(x => x.SaleDate)
            .Select(x => new SaleListItemModel
            {
                SaleId = x.SaleId,
                VoucherNo = x.VoucherNo,
                SaleDate = x.SaleDate,
                TotalAmount = x.TotalAmount,
                PaidAmount = x.PaidAmount,
                ChangeAmount = x.ChangeAmount
            })
            .ToList();

        return new SaleSearchResponseModel
        {
            IsSuccess = true,
            Message = "Sale search completed successfully.",
            Sales = sales
        };
    }
}