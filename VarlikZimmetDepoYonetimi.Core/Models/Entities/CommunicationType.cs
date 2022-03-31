using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class CommunicationType : BaseEntity, IEntity
    {
        [Key]
        public int CommunicationTypeID { get; set; }
        public string CommunicationTypeName { get; set; }
        public int MyProperty { get; set; }
    }
}
