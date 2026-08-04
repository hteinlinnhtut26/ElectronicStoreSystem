namespace ElectronicStore.Domain.Models.Product;

public class ProductByIdRequestModel
{
    public int ProductId { get; set; }
}

public class ProductByIdResponseModel
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;

    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }
}