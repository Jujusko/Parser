using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class Queries
    {
        public const string ConnectionString = @"Data Source=DESKTOP-16PSAEB;Initial Catalog=A2TZ;Integrated Security=True";

        public const string GetUserByINN = "GetUserByINN";
        public const string GetUserByName = "GetUserByName";
        public const string AddNewUser = "AddNewUser";
        public const string AddTranzaction = "AddTranzaction";
        public const string GetTranzactionByDeclaration = "GetTranzactionByDeclaration";
    }
}
