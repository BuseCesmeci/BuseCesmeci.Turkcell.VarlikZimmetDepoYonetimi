using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class AssetCustomerDTO : BaseDTO
    {
        public int AssetCustomerID { get; set; }
        public int AssetID { get; set; }
        public int CustomerID { get; set; }
    }
}
