using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class Communication : BaseEntity, IEntity
    {
        [Key]
        public int CommunicationID { get; set; }
        public int PersonnelID { get; set; }
        public int CommunicationTypeID { get; set; }
        public string Description { get; set; }
    }
}
