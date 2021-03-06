using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class AssetStatus : BaseEntity, IEntity
    {
        [Key]
        public int AssetStatusID { get; set; }
        public int? AssetID { get; set; }
        public int? PersonnelID { get; set; }
        public int? StatuID { get; set; }
        public string Note { get; set; }
    }
}
