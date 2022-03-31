using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class AssetWithoutBarcode : BaseEntity, IEntity
    {
        [Key]
        public int AssetWithoutBarcodeID { get; set; }
        public int AssetID { get; set; }
        public int UnitID { get; set; }
        public decimal Quantity { get; set; }
    }
}
