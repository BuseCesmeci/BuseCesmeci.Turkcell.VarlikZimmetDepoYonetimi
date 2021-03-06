using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Models.VM
{
    public class AssetDetailListVM : BaseDTO
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
        public DateTime? RetireDate { get; set; }

        //public IEnumerable<GuaranteeDTO> Guarantee { get; set; }
        //public int SelectedGuarantee { get; set; }


    }
}
