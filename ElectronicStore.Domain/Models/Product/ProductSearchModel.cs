using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.Domain.Models.Product
{
    public class ProductSearchRequestModel
    {
        public string Keyword { get; set; } = string.Empty;

    }
    public class ProductSearchResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<ProductListItemModel> Products { get; set; } = new(); 

    }
}
