using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class AssetOwnerDTO : BaseDTO
    {
        public int AssetOwnerID { get; set; }
        public int? AssetID { get; set; }
        public int? OwnerTypeID { get; set; }
        public int? OwnerID { get; set; }
        public int? DebitReasonID { get; set; }
        public DateTime? DebitStartDate { get; set; }
        public DateTime? DebitEndDate { get; set; }
    }
}
