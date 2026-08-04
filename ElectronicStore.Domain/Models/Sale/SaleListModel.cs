namespace ElectronicStore.Domain.Models.Sale;

public class SaleListRequestModel
{
}

public class SaleListResponseModel
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<SaleListItemModel> Sales { get; set; } = new();
}

public class SaleListItemModel
{
    public int SaleId { get; set; }

    public string VoucherNo { get; set; } = string.Empty;

    public DateTime SaleDate { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal PaidAmount { get; set; }

    public decimal ChangeAmount { get; set; }
}