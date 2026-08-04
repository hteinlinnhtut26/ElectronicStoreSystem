namespace ElectronicStore.Domain.Models.Product;

public class ProductDeleteRequestModel
{
    public int ProductId { get; set; }
}

public class ProductDeleteResponseModel
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;
}
