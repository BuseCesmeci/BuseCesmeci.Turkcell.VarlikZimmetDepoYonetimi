using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class BrandModelDTO : BaseDTO
    {
        public int BrandModelID { get; set; }
        public int UpperBrandModelID { get; set; }
        public bool UpperBrandModelMi { get; set; }
        public string BrandModelName { get; set; }
    }
}
