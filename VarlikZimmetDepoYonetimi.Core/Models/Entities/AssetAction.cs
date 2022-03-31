using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class AssetAction : BaseEntity, IEntity
    {
        public int AssetActionID { get; set; }
        public string AssetActionName { get; set; }
    }
}
