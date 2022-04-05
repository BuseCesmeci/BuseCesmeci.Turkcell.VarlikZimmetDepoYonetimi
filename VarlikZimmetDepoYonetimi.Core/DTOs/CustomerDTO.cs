using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class CustomerDTO : BaseDTO
    {
        public int CustomerID { get; set; }
        public string SubscriptionNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
