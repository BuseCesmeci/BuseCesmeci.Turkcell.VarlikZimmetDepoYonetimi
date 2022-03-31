using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class AssetGroup : BaseEntity, IEntity
    {
        [Key]
        public int AssetGroupID { get; set; }
        public string AssetGroupName { get; set; }
    }
}
