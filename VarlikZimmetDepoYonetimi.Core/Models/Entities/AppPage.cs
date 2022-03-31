using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class AppPage : BaseEntity, IEntity
    {
        [Key]
        public int AppPageID { get; set; }
        public string Description { get; set; }
    }
}
