using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class ActionStatusDTO : BaseDTO
    {
        public int ActionStatusID { get; set; }
        public int AssetActionID { get; set; }
        public int StatuID { get; set; }
    }
}
