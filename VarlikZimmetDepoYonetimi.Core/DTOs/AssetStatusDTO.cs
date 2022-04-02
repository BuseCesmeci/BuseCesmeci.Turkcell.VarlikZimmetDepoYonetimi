using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class AssetStatusDTO : BaseDTO
    {
        public int AssetStatusID { get; set; }
        public int AssetID { get; set; }
        public int PersonnelID { get; set; }
        public int StatuID { get; set; }
        public string Note { get; set; }
    }
}
