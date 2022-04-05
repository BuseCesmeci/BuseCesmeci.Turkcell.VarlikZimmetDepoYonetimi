using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class AssetDTO : BaseDTO
    {
        public int AssetID { get; set; }
        public string RegistrationNumber { get; set; }
        public int? AssetGroupID { get; set; }
        public int? AssetTypeID { get; set; }
        public int? BrandModelID { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public bool Guarantee { get; set; }
        public int? RetireReasonID { get; set; } 
        public DateTime? RetireDate { get; set; } = DateTime.Now;
        public int? CompanyID { get; set; }
    }
}
