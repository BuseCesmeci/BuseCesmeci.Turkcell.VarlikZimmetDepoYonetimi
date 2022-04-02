using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class AssetGroupDTO : BaseDTO
    {
        public int AssetGroupID { get; set; }
        public string AssetGroupName { get; set; }
    }
}
