using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class UserRole : BaseEntity, IEntity
    {
        [Key]
        public int UserRoleID { get; set; }
        public string UserRoleType { get; set; }
    }
}
