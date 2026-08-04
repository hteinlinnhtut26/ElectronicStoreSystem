namespace ElectronicStore.Domain.Models.Product;

public class ProductListRequestModel
{
}

public class ProductListResponseModel
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<ProductListItemModel> Products { get; set; } = new();
}

public class ProductListItemModel
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }
}