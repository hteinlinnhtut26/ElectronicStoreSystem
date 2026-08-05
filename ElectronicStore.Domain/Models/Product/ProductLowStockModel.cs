using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.Domain.Models.Product
{
    public class ProductLowStockRequestModel
    {
        public int Stock {  get; set; }
    }
    public class ProductLowStockResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<ProductListItemModel> Products { get; set; } = new();
    }

}
