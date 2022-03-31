using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.Models.Entities
{
    public class AssetBarcode : BaseEntity, IEntity
    {
        [Key]
        public int AssetBarcodeID { get; set; }
        public int AssetID { get; set; }
        public string Barcode { get; set; }
    }
}
