using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class AssetToReturnDTO : AssetStatusDTO
    {
        //iade et
        public CustomerDTO CustomerID { get; set; }
        public CustomerDTO SubscriptionNumber { get; set; }
    }
}
