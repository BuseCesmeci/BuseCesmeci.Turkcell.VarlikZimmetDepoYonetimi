using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class ActionStatus : BaseEntity, IEntity
    {
        [Key]
        public int ActionStatusID { get; set; }
        public int AssetActionID { get; set; }
        public int StatuID { get; set; }
    }
}
