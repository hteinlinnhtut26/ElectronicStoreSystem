namespace ElectronicStore.Domain.Models.Product;

public class ProductUpdateRequestModel
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }
}

public class ProductUpdateResponseModel
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;
}