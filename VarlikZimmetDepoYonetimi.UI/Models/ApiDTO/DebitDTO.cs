using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class DebitDTO : AssetStatusDTO
    {
        public int AssetOwnerID { get; set; }
        public int OwnerTypeID { get; set; }
        public string OwnerTypeName { get; set; }
        public DateTime DebitStartDate { get; set; } = DateTime.Now;
        public DateTime? DebitEndDate { get; set; }
        public string Description { get; set; }
    }
}
