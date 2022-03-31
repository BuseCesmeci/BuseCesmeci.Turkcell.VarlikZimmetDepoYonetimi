using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class AssetType : BaseEntity, IEntity
    {
        [Key]
        public int AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }
    }
}
