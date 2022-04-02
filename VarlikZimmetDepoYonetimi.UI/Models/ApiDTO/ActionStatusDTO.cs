using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class ActionStatusDTO : BaseDTO
    {
        public int ActionStatusID { get; set; }
        public int AssetActionID { get; set; }
        public int StatuID { get; set; }
    }
}
