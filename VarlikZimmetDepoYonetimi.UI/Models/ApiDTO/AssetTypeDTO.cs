using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class AssetTypeDTO : BaseDTO
    {
        public int AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }
    }
}
