using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class PersonnelDTO : BaseDTO
    {
        public int PersonnelID { get; set; }
        public int UpperID { get; set; }
        public bool UpperTeamMi { get; set; }
        public string Name { get; set; }
        public int CompanyID { get; set; }
    }
}
