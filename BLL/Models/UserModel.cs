using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string INN { get; set; }
        public bool SellerOrBuyer { get; set; }
    }
}
