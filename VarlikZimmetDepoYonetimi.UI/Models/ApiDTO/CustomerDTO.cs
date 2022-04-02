using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class CustomerDTO : BaseDTO
    {
        public int CustomerID { get; set; }
        public string SubscriptionNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
