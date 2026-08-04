
using ElectronicStore.Domain.Features.Product;
using ElectronicStore.Domain.Features.Sale;
using ElectronicStore.Domain.Models.Product;
using ElectronicStore.Domain.Models.Sale;

var productService = new ProductService();
var saleService = new SaleService();

Start:

Console.Clear();
Console.Title = "Electronic Store Product Management";

Console.WriteLine("==============================================");
Console.WriteLine("       ELECTRONIC STORE PRODUCT SYSTEM");
Console.WriteLine("==============================================");
Console.WriteLine("1. View Product List");
Console.WriteLine("2. Add Product");
Console.WriteLine("3. View Product By Id");
Console.WriteLine("4. Update Product");
Console.WriteLine("5. Delete Product");
Console.WriteLine("6. Create Sale");
Console.WriteLine("7. View Sale List");
Console.WriteLine("8. View Sale By Id");

Console.WriteLine("0. Exit");
Console.WriteLine("----------------------------------------------");
Console.Write("Choose an option: ");

int choose = Convert.ToInt32(Console.ReadLine());

if (choose == 1)
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("                PRODUCT LIST");
    Console.WriteLine("==============================================");

    var request = new ProductListRequestModel();

    var response = productService.GetProducts(request);

    var products = response.Products;

    if (products.Count == 0)
    {
        Console.WriteLine("No products found.");
    }
    else
    {
        Console.WriteLine(
            "{0,-5} {1,-25} {2,15} {3,10}",
            "ID",
            "Product Name",
            "Price",
            "Stock");

        Console.WriteLine(
            "------------------------------------------------------------");

        foreach (var item in products)
        {
            Console.WriteLine(
                "{0,-5} {1,-25} {2,15:N0} {3,10}",
                item.ProductId,
                item.ProductName,
                item.Price,
                item.StockQuantity);
        }

        Console.WriteLine(
            "------------------------------------------------------------");

        Console.WriteLine($"Total Products: {products.Count}");
    }
}
else if (choose == 2)
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("                 ADD PRODUCT");
    Console.WriteLine("==============================================");

    Console.Write("Product Name     : ");
    string productName = Console.ReadLine() ?? string.Empty;

    Console.Write("Price            : ");
    decimal price = Convert.ToDecimal(Console.ReadLine());

    Console.Write("Stock Quantity   : ");
    int stockQuantity = Convert.ToInt32(Console.ReadLine());

    var request = new ProductCreateRequestModel
    {
        ProductName = productName,
        Price = price,
        StockQuantity = stockQuantity
    };

    var response = productService.CreateProduct(request);

    Console.WriteLine();
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine(response.Message);

    if (response.IsSuccess)
    {
        Console.WriteLine($"New Product Id   : {response.ProductId}");
        Console.WriteLine($"Product Name     : {productName}");
        Console.WriteLine($"Price            : {price:N0}");
        Console.WriteLine($"Stock Quantity   : {stockQuantity}");
    }

    Console.WriteLine("----------------------------------------------");
}
else if (choose == 3)
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("             GET PRODUCT BY ID");
    Console.WriteLine("==============================================");

    Console.Write("Enter Product Id : ");
    int productId = Convert.ToInt32(Console.ReadLine());

    var request = new ProductByIdRequestModel
    {
        ProductId = productId
    };

    var response = productService.GetProductById(request);

    Console.WriteLine();

    if (!response.IsSuccess)
    {
        Console.WriteLine(response.Message);
    }
    else
    {
        Console.WriteLine($"Product Id   : {response.ProductId}");
        Console.WriteLine($"Product Name : {response.ProductName}");
        Console.WriteLine($"Price        : {response.Price:N0}");
        Console.WriteLine($"Stock        : {response.StockQuantity}");
    }
}
else if (choose == 4)
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("               UPDATE PRODUCT");
    Console.WriteLine("==============================================");

    Console.Write("Enter Product Id : ");
    int productId = Convert.ToInt32(Console.ReadLine());

    var byIdRequest = new ProductByIdRequestModel
    {
        ProductId = productId
    };

    var existingProduct =
        productService.GetProductById(byIdRequest);

    if (!existingProduct.IsSuccess)
    {
        Console.WriteLine();
        Console.WriteLine(existingProduct.Message);
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Current Product Information");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($"Product Name     : {existingProduct.ProductName}");
        Console.WriteLine($"Price            : {existingProduct.Price:N0}");
        Console.WriteLine($"Stock Quantity   : {existingProduct.StockQuantity}");
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine();
        Console.Write("New Product Name : ");
        string productName = Console.ReadLine() ?? string.Empty;

        Console.Write("New Price        : ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        Console.Write("New Stock        : ");
        int stockQuantity = Convert.ToInt32(Console.ReadLine());

        var request = new ProductUpdateRequestModel
        {
            ProductId = productId,
            ProductName = productName,
            Price = price,
            StockQuantity = stockQuantity
        };

        var response = productService.UpdateProduct(request);

        Console.WriteLine();
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine(response.Message);
        Console.WriteLine("----------------------------------------------");
    }
}
else if (choose == 5)
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("               DELETE PRODUCT");
    Console.WriteLine("==============================================");

    Console.Write("Enter Product Id : ");
    int productId = Convert.ToInt32(Console.ReadLine());

    var byIdRequest = new ProductByIdRequestModel
    {
        ProductId = productId
    };

    var product =
        productService.GetProductById(byIdRequest);

    if (!product.IsSuccess)
    {
        Console.WriteLine();
        Console.WriteLine(product.Message);
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Product Information");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($"Product Id       : {product.ProductId}");
        Console.WriteLine($"Product Name     : {product.ProductName}");
        Console.WriteLine($"Price            : {product.Price:N0}");
        Console.WriteLine($"Stock Quantity   : {product.StockQuantity}");
        Console.WriteLine("----------------------------------------------");

        Console.Write("Are you sure to delete? (Y/N): ");
        string answer = Console.ReadLine() ?? string.Empty;

        if (answer.ToUpper() == "Y")
        {
            var request = new ProductDeleteRequestModel
            {
                ProductId = productId
            };

            var response =
                productService.DeleteProduct(request);

            Console.WriteLine();
            Console.WriteLine(response.Message);
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Delete cancelled.");
        }
    }
}
else if (choose == 6)
{
    Console.Clear();

    Console.WriteLine("==============================================");
    Console.WriteLine("                 CREATE SALE");
    Console.WriteLine("==============================================");

    var request = new SaleCreateRequestModel();

AddItem:

    Console.Write("Enter Product Id      : ");
    int productId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter Quantity        : ");
    int quantity = Convert.ToInt32(Console.ReadLine());

    request.Items.Add(new SaleItemRequestModel
    {
        ProductId = productId,
        Quantity = quantity
    });

    Console.Write("Add another item? (Y/N): ");
    string answer = Console.ReadLine() ?? string.Empty;

    if (answer.ToUpper() == "Y")
    {
        goto AddItem;
    }

    Console.Write("Enter Paid Amount     : ");
    request.PaidAmount = Convert.ToDecimal(Console.ReadLine());

    var response = saleService.CreateSale(request);

    Console.WriteLine();
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine(response.Message);

    if (response.IsSuccess)
    {
        Console.WriteLine($"Sale Id              : {response.SaleId}");
        Console.WriteLine($"Voucher No           : {response.VoucherNo}");
        Console.WriteLine($"Total Amount         : {response.TotalAmount:N0}");
        Console.WriteLine($"Paid Amount          : {response.PaidAmount:N0}");
        Console.WriteLine($"Change Amount        : {response.ChangeAmount:N0}");
    }

    Console.WriteLine("----------------------------------------------");
}

else if (choose == 7)
{
    Console.Clear();

    Console.WriteLine("==============================================================");
    Console.WriteLine("                         SALE LIST");
    Console.WriteLine("==============================================================");

    var request = new SaleListRequestModel();

    var response = saleService.GetSales(request);

    if (!response.IsSuccess)
    {
        Console.WriteLine(response.Message);
    }
    else
    {
        Console.WriteLine(
            "{0,-8} {1,-24} {2,-20} {3,14} {4,14} {5,14}",
            "Sale Id",
            "Voucher No",
            "Sale Date",
            "Total",
            "Paid",
            "Change");

        Console.WriteLine(
            "------------------------------------------------------------------------------------------------");

        foreach (var item in response.Sales)
        {
            Console.WriteLine(
                "{0,-8} {1,-24} {2,-20:yyyy-MM-dd HH:mm} {3,14:N0} {4,14:N0} {5,14:N0}",
                item.SaleId,
                item.VoucherNo,
                item.SaleDate,
                item.TotalAmount,
                item.PaidAmount,
                item.ChangeAmount);
        }

        Console.WriteLine(
            "------------------------------------------------------------------------------------------------");

        Console.WriteLine($"Total Sale Records: {response.Sales.Count}");
    }
}

else if (choose == 8)
{
    Console.Clear();

    Console.WriteLine("==============================================================");
    Console.WriteLine("                      SALE VOUCHER DETAIL");
    Console.WriteLine("==============================================================");

    Console.Write("Enter Sale Id: ");
    int saleId = Convert.ToInt32(Console.ReadLine());

    var request = new SaleByIdRequestModel
    {
        SaleId = saleId
    };

    var response = saleService.GetSaleById(request);

    if (!response.IsSuccess)
    {
        Console.WriteLine();
        Console.WriteLine(response.Message);
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine($"Voucher No   : {response.VoucherNo}");
        Console.WriteLine($"Sale Date    : {response.SaleDate:yyyy-MM-dd HH:mm}");
        Console.WriteLine($"Sale Id      : {response.SaleId}");
        Console.WriteLine("--------------------------------------------------------------");

        Console.WriteLine(
            "{0,-5} {1,-22} {2,8} {3,14} {4,14}",
            "ID",
            "Product Name",
            "Qty",
            "Unit Price",
            "Line Total");

        Console.WriteLine(
            "--------------------------------------------------------------");

        foreach (var item in response.Items)
        {
            Console.WriteLine(
                "{0,-5} {1,-22} {2,8} {3,14:N0} {4,14:N0}",
                item.ProductId,
                item.ProductName,
                item.Quantity,
                item.UnitPrice,
                item.LineTotal);
        }

        Console.WriteLine(
            "--------------------------------------------------------------");

        Console.WriteLine($"Total Amount : {response.TotalAmount,14:N0}");
        Console.WriteLine($"Paid Amount  : {response.PaidAmount,14:N0}");
        Console.WriteLine($"Change Amount: {response.ChangeAmount,14:N0}");
    }
}

else if (choose == 0)
{
    goto Exit;
}
else
{
    Console.WriteLine();
    Console.WriteLine("Invalid option. Please choose from 0 to 8.");
}

Console.WriteLine();
Console.WriteLine("Press any key to return to menu...");
Console.ReadKey();

goto Start;

Exit:

Console.Clear();
Console.WriteLine("==============================================");
Console.WriteLine("             PROGRAM CLOSED");
Console.WriteLine("==============================================");
Console.WriteLine("Press any key to exit.");
Console.ReadKey();