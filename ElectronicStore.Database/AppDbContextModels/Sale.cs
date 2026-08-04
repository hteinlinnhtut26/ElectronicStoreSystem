using System;
using System.Collections.Generic;

namespace ElectronicStore.Database.AppDbContextModels;

public partial class Sale
{
    public int SaleId { get; set; }

    public string VoucherNo { get; set; } = null!;

    public DateTime SaleDate { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal PaidAmount { get; set; }

    public decimal ChangeAmount { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
}
