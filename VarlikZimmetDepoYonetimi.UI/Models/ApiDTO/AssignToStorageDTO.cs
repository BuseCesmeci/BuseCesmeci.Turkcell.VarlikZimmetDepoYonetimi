using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class AssignToStorageDTO : AssetStatusDTO
    {
        public CompanyDTO CompanyID { get; set; }
        public CompanyDTO CompanyName { get; set; }
    }
}
