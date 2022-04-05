using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class AssetBarcodeDTO : BaseDTO
    {
        public int AssetBarcodeID { get; set; }
        public int AssetID { get; set; }
        public string Barcode { get; set; }
    }
}
