using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class AppPageProcessClaim : BaseEntity, IEntity
    {
        [Key]
        public int AppPageProcessClaimID { get; set; }
        public int UserRoleID { get; set; }
        public int AppPageID { get; set; }
        public int ProcessClaimID { get; set; }
    }
}
