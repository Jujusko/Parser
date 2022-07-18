using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataTransferObjects
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string INN { get; set; }
        public string Name { get; set; }
        public bool SellerOrBuyer { get; set; }
    }
}
