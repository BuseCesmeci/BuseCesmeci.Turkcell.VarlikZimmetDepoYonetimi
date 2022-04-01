using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class CurrencyDTO : BaseDTO
    {
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
    }
}
