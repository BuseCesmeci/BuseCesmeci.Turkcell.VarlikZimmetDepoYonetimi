using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class Company : BaseEntity, IEntity
    {
        [Key]
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
    }
}
