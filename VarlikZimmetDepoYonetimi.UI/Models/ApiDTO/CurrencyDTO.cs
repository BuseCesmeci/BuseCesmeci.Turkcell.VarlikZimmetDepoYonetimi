using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class CurrencyDTO : BaseDTO
    {
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
    }
}
