using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class Asset : BaseEntity, IEntity
    {
        [Key]
        public int AssetID { get; set; }
        public string RegistrationNumber { get; set; }
        public int? AssetGroupID { get; set; }
        public int? AssetTypeID { get; set; }
        public int? BrandModelID { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public bool Guarantee { get; set; }
        public int? RetireReasonID { get; set; }
        public DateTime RetireDate { get; set; }
        public int? CompanyID { get; set; }
    }
}
