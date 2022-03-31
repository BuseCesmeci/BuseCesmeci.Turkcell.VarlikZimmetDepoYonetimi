using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class AssetOwner : BaseEntity, IEntity
    {
        [Key]
        public int AssetOwnerID { get; set; }
        public int AssetID { get; set; }
        public int OwnerTypeID { get; set; }
        public string Owner { get; set; }
    }
}
