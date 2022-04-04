using AutoMapper;
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
    public class AssetActionOptionsController : ControllerBase
    {
        IAssetActionOptionsDAL _assetActionOptionsDal;
        IMapper _mapper;

        public AssetActionOptionsController(IAssetActionOptionsDAL assetActionOptionsDAL, IMapper mapper)
        {
            _assetActionOptionsDal = assetActionOptionsDAL;
            _mapper = mapper;
        }

        // Zimmete çıkarma nedeni, zimmet ata aksiyonu

        [HttpGet]
        [Route("~/api/assetactionoptions")]
        public async Task<DebitReasonLoadDTO> GetDebitReason()
        {
            var debitReason = _assetActionOptionsDal.GetAll(x => x.isActive == true && x.MasterOptionID == 1 && x.MasterOptionMi == false);
            DebitReasonLoadDTO drDto = new DebitReasonLoadDTO();
            drDto.ActionOptions = (from ao in debitReason
                                   select new AssetActionOptionsDTO 
                                   {
                                        AssetActionOptionsID = ao.AssetActionOptionsID,
                                        AssetActionOptionName = ao.AssetActionOptionName
                                   }).ToList();

            return drDto;
        }

    }
}
