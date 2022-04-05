using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class PriceDTO : BaseDTO
    {
        public int PriceID { get; set; }
        public int AssetID { get; set; }
        public decimal AssetPrice { get; set; }
        public int? CurrencyID { get; set; }
    }
}
