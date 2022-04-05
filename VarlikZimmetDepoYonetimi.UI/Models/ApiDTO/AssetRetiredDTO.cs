using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class AssetRetiredDTO
    {
        public List<AssetActionOptionsDTO> DebitRetiredReason { get; set; }
        public int SelectedDebitRetiredReason { get; set; }
        public string Description { get; set; }
    }
}
