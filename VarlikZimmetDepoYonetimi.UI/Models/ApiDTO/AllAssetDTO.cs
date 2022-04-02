using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
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
        //public int AssetID { get; set; }
        //public string RegistrationNumber { get; set; }
        //public int AssetBarcodeID { get; set; }
        //public string Barcode { get; set; }
        //public int AssetTypeID { get; set; }
        //public string AssetTypeName { get; set; }
        //public int PriceID { get; set; }
        //public decimal AssetPrice { get; set; }
        //public int BrandModelID { get; set; }
        //public string BrandModelName { get; set; }
        //public int AssetGroupID { get; set; }
        //public string AssetGroupName { get; set; }
        //public bool isActive { get; set; }
    }
}
