using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class PriceDTO : BaseDTO
    {
        public int PriceID { get; set; }
        public int AssetID { get; set; }
        public decimal AssetPrice { get; set; }
        public int CurrencyID { get; set; }
    }
}
