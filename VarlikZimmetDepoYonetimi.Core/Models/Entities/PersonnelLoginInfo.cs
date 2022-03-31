using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class PersonnelLoginInfo : BaseEntity, IEntity
    {
        [Key]
        public int PersonnelLoginInfoID { get; set; }
        public int PersonnelID { get; set; }
        public int LoginInfoID { get; set; }
    }
}
