using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VarlikZimmetDepoYonetimi.UI.Models.ApiDTO
{
    public class DropDownLoadDTO
    {
        public List<AssetTypeDTO> AssetType { get; set; }
        public List<BrandModelDTO> Brand { get; set; }
        public List<BrandModelDTO> Model { get; set; }
        public List<CurrencyDTO> Currency { get; set; }
        public List<AssetGroupDTO> AssetGroup { get; set; }
    }
}
