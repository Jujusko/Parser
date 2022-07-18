using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class TranzactionModel
    {
        public string Declaration { get; set; }
        public string SellerName { get; set; }
        public string SellerINN { get; set; }
        public string BuyerName { get; set; }
        public string BuyerINN { get; set; }
        public string Date { get; set; }
        public string Value { get; set; }
    }
}
