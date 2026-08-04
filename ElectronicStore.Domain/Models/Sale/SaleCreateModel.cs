namespace ElectronicStore.Domain.Models.Sale;

public class SaleCreateRequestModel
{
    public decimal PaidAmount { get; set; }

    public List<SaleItemRequestModel> Items { get; set; } = new();
}

public class SaleItemRequestModel
{
    public int ProductId { get; set; }

    public int Quantity { get; set; }
}

public class SaleCreateResponseModel
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;

    public int SaleId { get; set; }

    public string VoucherNo { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }

    public decimal PaidAmount { get; set; }

    public decimal ChangeAmount { get; set; }
}