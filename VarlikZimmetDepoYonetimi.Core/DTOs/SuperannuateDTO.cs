using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class SuperannuateDTO : AssetStatusDTO
    {
        public List<AssetActionOptionsDTO> WhySuperannuate { get; set; }
    }
}
