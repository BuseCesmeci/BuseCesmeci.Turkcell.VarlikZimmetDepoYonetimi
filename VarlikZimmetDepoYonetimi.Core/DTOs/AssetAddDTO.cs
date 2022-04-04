using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.Core.DTOs
{
    public class AssetAddDTO : BaseDTO
    {
        public List<AssetTypeDTO> AssetType { get; set; }
        public int SelectedAssetType { get; set; }

        public List<BrandModelDTO> Brand { get; set; }
        public int SelectedBrand { get; set; }
        public List<BrandModelDTO> Model { get; set; }
        public int SelectedModel { get; set; }

        public List<CurrencyDTO> Currency { get; set; }
        public int SelectedCurrency { get; set; }
        public int AssetID { get; set; }
        public string RegistrationNumber { get; set; }
        public decimal Cost { get; set; }
        public int? AssetBarcodeID { get; set; }
        public string Description { get; set; }
        public int PriceID { get; set; }
        public decimal AssetPrice { get; set; }
        public DateTime? RetireDate { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public int AssetWithoutBarcodeID { get; set; }
        public decimal Quantity { get; set; }

    }
}
