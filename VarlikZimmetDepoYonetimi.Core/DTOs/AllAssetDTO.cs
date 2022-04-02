using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class AllAssetDTO
    {
        public AssetDTO AssetID { get; set; }
        public AssetDTO RegistrationNumber { get; set; }
        public AssetBarcodeDTO AssetBarcodeID { get; set; }
        public AssetBarcodeDTO Barcode { get; set; }
        public AssetTypeDTO AssetTypeID { get; set; }
        public AssetTypeDTO AssetTypeName { get; set; }
        public PriceDTO PriceID { get; set; }
        public PriceDTO AssetPrice { get; set; }
        public BrandModelDTO BrandModelID { get; set; }
        public BrandModelDTO BrandModelName { get; set; }
        public AssetGroupDTO AssetGroupID { get; set; }
        public AssetGroupDTO AssetGroupName { get; set; }
        public bool isActive { get; set; }
    }
}
