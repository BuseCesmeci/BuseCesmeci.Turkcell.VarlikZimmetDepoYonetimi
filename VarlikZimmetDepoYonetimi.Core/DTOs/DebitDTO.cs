using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class DebitDTO : AssetStatusDTO
    {
        public int AssetOwnerID { get; set; }
        public int OwnerTypeID { get; set; }
        public string OwnerTypeName { get; set; }
        public int AssetActionOptionsID { get; set; }
        public string AssetActionOptionName { get; set; }
        public DateTime DebitStartDate { get; set; } = DateTime.Now;

    }
}
