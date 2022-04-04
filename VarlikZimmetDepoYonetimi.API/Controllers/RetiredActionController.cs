using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.Core.DTOs;
using VarlikZimmetDepoYonetimi.Data.DAL;

namespace VarlikZimmetDepoYonetimi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetiredActionController : ControllerBase
    {
        IAssetActionOptionsDAL _assetActionOptionsDal;
        public RetiredActionController(IAssetActionOptionsDAL assetActionOptionsDAL)
        {
            _assetActionOptionsDal = assetActionOptionsDAL;
        }

        // emekli et aksiyonu emeklilik nedeni

        [HttpGet]
        [Route("~/api/retiredaction")]
        public async Task<DebitRetiredLoadDTO> GetDebitRetired()
        {
            var debitRetired = _assetActionOptionsDal.GetAll(x => x.isActive == true && x.MasterOptionID == 2 && x.MasterOptionMi == false);
            DebitRetiredLoadDTO retiredDto = new DebitRetiredLoadDTO();
            retiredDto.DebitRetiredReason = (from r in debitRetired
                                             select new AssetActionOptionsDTO
                                             {
                                                 AssetActionOptionsID = r.AssetActionOptionsID,
                                                 AssetActionOptionName = r.AssetActionOptionName
                                             }).ToList();
            return retiredDto;
        }
    }
}
