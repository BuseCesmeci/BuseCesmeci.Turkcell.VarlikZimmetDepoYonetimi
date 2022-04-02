using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class SuperannuateDTO : AssetStatusDTO
    {
        public List<AssetActionOptionsDTO> WhySuperannuate { get; set; }
    }
}
