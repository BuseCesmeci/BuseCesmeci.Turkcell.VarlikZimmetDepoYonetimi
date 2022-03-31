using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class AssetDTO : BaseDTO
    {
        public int AssetID { get; set; }
        public string RegistrationNumber { get; set; }
        public int AssetGroupID { get; set; }
        public int AssetTypeID { get; set; }
        public int BrandModelID { get; set; }
        public int PersonnelTeamID { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public bool Guarantee { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime RetireDate { get; set; }
    }
}
