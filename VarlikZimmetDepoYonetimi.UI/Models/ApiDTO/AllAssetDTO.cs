using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class AllAssetDTO
    {
        public List<AssetDTO> Asset { get; set; }
        public List<AssetBarcodeDTO> Barcode { get; set; }
        public List<AssetTypeDTO> AssetType { get; set; }
        public List<AssetGroupDTO> AssetGroup { get; set; }
        public List<PriceDTO> Price { get; set; }
        public List<BrandModelDTO> Brand { get; set; }
        public List<BrandModelDTO> Model { get; set; }

    }
}
