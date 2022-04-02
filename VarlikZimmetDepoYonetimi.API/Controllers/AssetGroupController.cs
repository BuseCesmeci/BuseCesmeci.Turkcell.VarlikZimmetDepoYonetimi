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
    public class AssetGroupController : ControllerBase
    {
        IAssetGroupDAL _assetGroupDal;
        IMapper _mapper;

        public AssetGroupController(IAssetGroupDAL assetGroupDAL, IMapper mapper)
        {
            _assetGroupDal = assetGroupDAL;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAssetGroupAsync()
        {
            var value = await _assetGroupDal.GetAllAsync(x => x.isActive == true);
            return Ok(_mapper.Map<IEnumerable<AssetGroupDTO>>(value));
        }
    }
}
