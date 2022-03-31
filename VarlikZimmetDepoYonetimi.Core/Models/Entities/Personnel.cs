using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class Personnel : BaseEntity, IEntity
    {
        [Key]
        public int PersonnelID { get; set; }
        public int UpperID { get; set; }
        public bool UpperTeamMi { get; set; }
        public string Name { get; set; }
    }
}
