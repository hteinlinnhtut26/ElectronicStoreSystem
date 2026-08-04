namespace ElectronicStore.Domain.Models.Sale;

public class SaleByIdRequestModel
{
    public int SaleId { get; set; }
}

public class SaleByIdResponseModel
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;

    public int SaleId { get; set; }

    public string VoucherNo { get; set; } = string.Empty;

    public DateTime SaleDate { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal PaidAmount { get; set; }

    public decimal ChangeAmount { get; set; }

    public List<SaleByIdItemModel> Items { get; set; } = new();
}

public class SaleByIdItemModel
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal LineTotal { get; set; }
}