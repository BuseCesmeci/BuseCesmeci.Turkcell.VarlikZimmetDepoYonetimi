using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class ToConsumeDTO : AssetStatusDTO
    {
        public CustomerDTO CustomerID { get; set; }
        public CustomerDTO SubscriptionNumber { get; set; }
    }
}
