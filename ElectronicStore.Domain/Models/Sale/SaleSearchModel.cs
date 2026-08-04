using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.Domain.Models.Sale
{
    public class SaleSearchRequestModel
    {
        public string KeyWord { get; set; } = string.Empty;
    }

    public class SaleSearchResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<SaleListItemModel> Sales { get; set; } = new();
    }
}
