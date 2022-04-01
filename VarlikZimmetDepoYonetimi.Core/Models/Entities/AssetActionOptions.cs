using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class AssetActionOptions : BaseEntity, IEntity
    {
        [Key]
        public int AssetActionOptionsID { get; set; }
        public int? MasterOptionID { get; set; }
        public bool MasterOptionMi { get; set; }
        public string AssetActionOptionName { get; set; }

    }
}
