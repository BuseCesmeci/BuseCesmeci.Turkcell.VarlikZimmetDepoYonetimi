using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class Currency : BaseEntity, IEntity
    {
        [Key]
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
    }
}
