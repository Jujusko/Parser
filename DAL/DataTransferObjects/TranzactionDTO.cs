using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataTransferObjects
{
    public class TranzactionDTO
    {
        public int Id { get; set; }
        public string Declaration { get; set; }
        public int SellerId { get; set; }
        public int BuyerId { get; set; }
        public string Date { get; set; }
        public string Value { get;set; }
    }
}
