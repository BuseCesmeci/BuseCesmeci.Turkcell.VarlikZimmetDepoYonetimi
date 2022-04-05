using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class DebitDTO : AssetStatusDTO
    {
        public List<AssetActionOptionsDTO> ActionOptions { get; set; }
        public int SelectedActionOptions { get; set; }
        public int AssetOwnerID { get; set; }
        public int? OwnerID { get; set; }
        public int OwnerTypeID { get; set; }
        public string OwnerTypeName { get; set; }
        public DateTime DebitStartDate { get; set; } = DateTime.Now;
        public DateTime? DebitEndDate { get; set; }
        public string Description { get; set; }

    }
}
