using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class AssetToReturnDTO : AssetStatusDTO
    {
        // iade et, tüket
        public CustomerDTO CustomerID { get; set; }
        public CustomerDTO SubscriptionNumber { get; set; }
    }
}
