using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class AssignToStorageDTO : AssetStatusDTO
    {
        public CompanyDTO CompanyID { get; set; }
        public CompanyDTO CompanyName { get; set; }

    }
}
