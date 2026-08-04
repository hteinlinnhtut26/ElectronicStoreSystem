using ElectronicStore.Database.AppDbContextModels;
using ElectronicStore.Domain.Models.Product;

namespace ElectronicStore.Domain.Features.Product;

public class ProductService
{
    private readonly AppDbContext _db;

    public ProductService()
    {
        _db = new AppDbContext();
    }

    public ProductCreateResponseModel CreateProduct(
        ProductCreateRequestModel request)
    {
        if (string.IsNullOrWhiteSpace(request.ProductName))
        {
            return new ProductCreateResponseModel
            {
                IsSuccess = false,
                Message = "Product name is required."
            };
        }

        if (request.Price <= 0)
        {
            return new ProductCreateResponseModel
            {
                IsSuccess = false,
                Message = "Price must be greater than zero."
            };
        }

        if (request.StockQuantity < 0)
        {
            return new ProductCreateResponseModel
            {
                IsSuccess = false,
                Message = "Stock quantity cannot be negative."
            };
        }

        var product = new Database.AppDbContextModels.Product
        {
            ProductName = request.ProductName,
            Price = request.Price,
            StockQuantity = request.StockQuantity
        };

        _db.Products.Add(product);
        _db.SaveChanges();

        return new ProductCreateResponseModel
        {
            IsSuccess = true,
            Message = "Product created successfully.",
            ProductId = product.ProductId
        };
    }

    public ProductListResponseModel GetProducts(
        ProductListRequestModel request)
    {
        var products = _db.Products
            .OrderBy(x => x.ProductId)
            .Select(x => new ProductListItemModel
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Price = x.Price,
                StockQuantity = x.StockQuantity
            })
            .ToList();

        return new ProductListResponseModel
        {
            IsSuccess = true,
            Message = "Product list received successfully.",
            Products = products
        };
    }

    public ProductByIdResponseModel GetProductById(
        ProductByIdRequestModel request)
    {
        var product = _db.Products
            .Where(x => x.ProductId == request.ProductId)
            .Select(x => new ProductByIdResponseModel
            {
                IsSuccess = true,
                Message = "Product found.",
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Price = x.Price,
                StockQuantity = x.StockQuantity
            })
            .FirstOrDefault();

        if (product == null)
        {
            return new ProductByIdResponseModel
            {
                IsSuccess = false,
                Message = "Product not found."
            };
        }

        return product;
    }

    public ProductUpdateResponseModel UpdateProduct(
        ProductUpdateRequestModel request)
    {
        var product = _db.Products
            .FirstOrDefault(x => x.ProductId == request.ProductId);

        if (product == null)
        {
            return new ProductUpdateResponseModel
            {
                IsSuccess = false,
                Message = "Product not found."
            };
        }

        if (string.IsNullOrWhiteSpace(request.ProductName))
        {
            return new ProductUpdateResponseModel
            {
                IsSuccess = false,
                Message = "Product name is required."
            };
        }

        if (request.Price <= 0)
        {
            return new ProductUpdateResponseModel
            {
                IsSuccess = false,
                Message = "Price must be greater than zero."
            };
        }

        if (request.StockQuantity < 0)
        {
            return new ProductUpdateResponseModel
            {
                IsSuccess = false,
                Message = "Stock quantity cannot be negative."
            };
        }

        product.ProductName = request.ProductName;
        product.Price = request.Price;
        product.StockQuantity = request.StockQuantity;

        _db.SaveChanges();

        return new ProductUpdateResponseModel
        {
            IsSuccess = true,
            Message = "Product updated successfully."
        };
    }

    public ProductDeleteResponseModel DeleteProduct(
        ProductDeleteRequestModel request)
    {
        var product = _db.Products
            .FirstOrDefault(x => x.ProductId == request.ProductId);

        if (product == null)
        {
            return new ProductDeleteResponseModel
            {
                IsSuccess = false,
                Message = "Product not found."
            };
        }

        bool isUsedInSale = _db.SaleDetails
            .Any(x => x.ProductId == request.ProductId);

        if (isUsedInSale)
        {
            return new ProductDeleteResponseModel
            {
                IsSuccess = false,
                Message = "This product cannot be deleted because it is already used in a sale."
            };
        }

        _db.Products.Remove(product);
        _db.SaveChanges();

        return new ProductDeleteResponseModel
        {
            IsSuccess = true,
            Message = "Product deleted successfully."
        };
    }
}