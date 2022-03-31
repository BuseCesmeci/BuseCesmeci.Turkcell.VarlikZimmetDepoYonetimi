using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class Statu : BaseEntity, IEntity
    {
        [Key]
        public int StatuID { get; set; }
        public string StatuType { get; set; }
    }
}
