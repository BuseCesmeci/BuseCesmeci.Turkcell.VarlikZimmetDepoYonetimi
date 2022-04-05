using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class AssetInfoPageTableDTO
    {
        public AssetDTO AssetID { get; set; }
        public AssetDTO CreateDate { get; set; }
        public AssetStatusDTO Status { get; set; }
        public AssetStatusDTO Note { get; set; }
        public AssetActionDTO AssetActionID { get; set; }
        public AssetActionDTO AssetActionName { get; set; }
        public AssetActionDTO ModifiedDate { get; set; }
        public PersonnelDTO PersonnelID { get; set; }
        public PersonnelDTO Name { get; set; }


    }
}
