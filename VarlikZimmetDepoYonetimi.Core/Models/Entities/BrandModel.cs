using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class BrandModel : BaseEntity, IEntity
    {
        [Key]
        public int BrandModelID { get; set; }
        public int UpperBrandModelID { get; set; }
        public bool UpperBrandModelMi { get; set; }
        public string BrandModelName { get; set; }
    }
}
