using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class AssetActionDTO : BaseDTO
    {
        public int AssetActionID { get; set; }
        public string AssetActionName { get; set; }
    }
}
