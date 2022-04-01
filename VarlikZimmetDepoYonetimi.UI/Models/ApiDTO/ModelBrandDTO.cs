using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class ModelBrandDTO : BaseDTO
    {
        public int BrandModelID { get; set; }
        public int UpperBrandModelID { get; set; }
        public bool UpperBrandModelMi { get; set; }
        public string BrandModelName { get; set; }
    }
}
