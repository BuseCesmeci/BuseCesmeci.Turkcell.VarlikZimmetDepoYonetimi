using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class Price : BaseEntity, IEntity
    {
        [Key]
        public int PriceID { get; set; }
        public int AssetID { get; set; }
        public decimal AssetPrice { get; set; }
        public int CurrencyID { get; set; }
    }
}
