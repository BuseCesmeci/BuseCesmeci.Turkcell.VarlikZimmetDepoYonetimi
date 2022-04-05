using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class AssetActionOptionsDTO : BaseDTO
    {
        public int AssetActionOptionsID { get; set; }
        public int? MasterOptionID { get; set; }
        public bool MasterOptionMi { get; set; }
        public string AssetActionOptionName { get; set; }
    }
}
