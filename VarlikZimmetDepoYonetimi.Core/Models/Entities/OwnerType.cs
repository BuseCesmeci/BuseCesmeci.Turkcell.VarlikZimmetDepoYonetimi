using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class OwnerType : BaseEntity, IEntity
    {
        [Key]
        public int OwnerTypeID { get; set; }
        public string OwnerTypeName { get; set; }
    }
}
