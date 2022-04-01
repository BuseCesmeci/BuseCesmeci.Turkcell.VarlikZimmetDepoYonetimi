using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Models.VM
{
    public class AssetDetailListVM
    {
        public IEnumerable<AssetTypeDTO> AssetType { get; set; }
        public int SelectedAssetType { get; set; }

        public IEnumerable<BrandModelDTO> Brand { get; set; }
        public int SelectedBrand { get; set; }

        public IEnumerable<BrandModelDTO> Model { get; set; }
        public int SelectedModel { get; set; }

        public IEnumerable<GuaranteeDTO> Guarantee { get; set; }
        public int SelectedGuarantee { get; set; }

        public IEnumerable<CurrencyDTO> Currency { get; set; }
        public int SelectedCurrency { get; set; }

    }
}
