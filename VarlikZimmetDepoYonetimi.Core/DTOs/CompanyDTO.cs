using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class CompanyDTO : BaseDTO
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
    }
}
