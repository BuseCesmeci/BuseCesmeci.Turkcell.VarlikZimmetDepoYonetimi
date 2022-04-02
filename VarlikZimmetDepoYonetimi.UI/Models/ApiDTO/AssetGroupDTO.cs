using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class AssetGroupDTO : BaseDTO
    {
        public int AssetGroupID { get; set; }
        public string AssetGroupName { get; set; }
    }
}
