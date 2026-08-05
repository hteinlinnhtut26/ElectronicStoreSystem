using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.Domain.Models.Product;

public class ProductRestockRequestModel
{
    public int ProductId { get; set; }

    public int Quantity { get; set; }
}

public class ProductRestockResponseModel
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;
}
