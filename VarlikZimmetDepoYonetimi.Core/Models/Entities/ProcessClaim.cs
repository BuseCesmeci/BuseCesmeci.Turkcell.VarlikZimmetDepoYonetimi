using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class ProcessClaim : BaseEntity, IEntity
    {
        [Key]
        public int ProcessClaimID { get; set; }
        public string Description { get; set; }
    }
}
