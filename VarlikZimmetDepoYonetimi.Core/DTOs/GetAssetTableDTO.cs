using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class GetAssetTableDTO
    {
        public int AssetID { get; set; }
        public string RegistrationNumber { get; set; }
        public int AssetBarcodeID { get; set; }
        public string Barcode { get; set; }
        public int AssetTypeID { get; set; }
        public string AssetTypeName { get; set; }
        public int PriceID { get; set; }
        public decimal AssetPrice { get; set; }
        public int BrandModelID { get; set; }
        public string BrandModelName { get; set; }
        public int AssetGroupID { get; set; }
        public string AssetGroupName { get; set; }
        public bool isActive { get; set; }
    }
}
