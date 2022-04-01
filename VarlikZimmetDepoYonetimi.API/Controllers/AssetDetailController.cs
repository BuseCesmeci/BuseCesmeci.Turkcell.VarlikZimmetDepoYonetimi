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
    public class AssetDetailController : ControllerBase
    {
        // listeleri dönen bir tip tipin propları list olacak get metodu

        IBrandModelDAL _brandModelDal;
        IAssetTypeDAL _assetTypeDal;
        IMapper _mapper;

        public AssetDetailController(IBrandModelDAL brandModelDAL, IAssetTypeDAL assetTypeDAL, IMapper mapper)
        {
            _brandModelDal = brandModelDAL;
            _assetTypeDal = assetTypeDAL;
            _mapper = mapper;
        }
               

        public async Task<DropDownLoadDTO> GetAssetDetail()
        {
            var value =  _brandModelDal.GetAll(x => x.isActive == true);
            DropDownLoadDTO dto = new DropDownLoadDTO();
            dto.Brand = (from p in value
                         select new BrandModelDTO
                         {
                             BrandModelID = p.BrandModelID,
                             BrandModelName = p.BrandModelName
                         }).ToList();

            var value2 = _assetTypeDal.GetAll(x => x.isActive == true);
            List<AssetTypeDTO> listDto = new List<AssetTypeDTO>();
            foreach (var item in value2)
            {
                listDto.Add(_mapper.Map<AssetTypeDTO>(value2));
            }
            dto.AssetType = listDto;
            

            return dto;
        }
        

    }
}
