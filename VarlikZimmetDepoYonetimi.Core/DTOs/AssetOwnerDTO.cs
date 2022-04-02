using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class AssetOwnerDTO : BaseDTO
    {
        public int AssetOwnerID { get; set; }
        public int AssetID { get; set; }
        public int OwnerTypeID { get; set; }
        public string Owner { get; set; }
    }
}
