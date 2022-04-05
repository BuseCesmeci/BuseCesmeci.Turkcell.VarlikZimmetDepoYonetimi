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

        IBrandModelDAL _brandModelDal;
        IAssetTypeDAL _assetTypeDal;
        ICurrencyDAL _currencyDal;
        IAssetGroupDAL _assetGroupDal;
        IMapper _mapper;

        public AssetDetailController(IBrandModelDAL brandModelDAL, IAssetTypeDAL assetTypeDAL,ICurrencyDAL currencyDAL, IAssetGroupDAL assetGroupDAL, IMapper mapper)
        {
            _brandModelDal = brandModelDAL;
            _assetTypeDal = assetTypeDAL;
            _currencyDal = currencyDAL;
            _assetGroupDal = assetGroupDAL;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("~/api/assetdetail")]
        public async Task<DropDownLoadDTO> GetAssetDetail()
        {
            var value =  _brandModelDal.GetAll(x => x.isActive == true && x.UpperBrandModelMi == true);
            DropDownLoadDTO dto = new DropDownLoadDTO();
            dto.Brand = (from p in value
                         select new BrandModelDTO
                         {
                             BrandModelID = p.BrandModelID,
                             BrandModelName = p.BrandModelName
                         }).ToList();


            var value2 = _assetTypeDal.GetAll(x => x.isActive == true);
            dto.AssetType = (from a in value2
                             select new AssetTypeDTO 
                             { 
                                AssetTypeID = a.AssetTypeID,
                                AssetTypeName = a.AssetTypeName
                             }).ToList();

            //List<AssetTypeDTO> listAssetType = new List<AssetTypeDTO>();
            //foreach (var item in value2)
            //{
            //    listAssetType.Add(_mapper.Map<AssetTypeDTO>(value2));
            //}
            //dto.AssetType = listAssetType;

             var value3 = _currencyDal.GetAll(x => x.isActive == true);
            dto.Currency = (from c in value3
                            select new CurrencyDTO 
                            {
                                CurrencyID = c.CurrencyID,
                                CurrencyName = c.CurrencyName
                            }).ToList();
            //List<CurrencyDTO> listCurrency = new List<CurrencyDTO>();
            //foreach (var item in value3)
            //{
            //    listCurrency.Add(_mapper.Map<CurrencyDTO>(value3));
            //}
            //dto.Currency = listCurrency;

            var value4 = _brandModelDal.GetAll(x => x.isActive == true && x.UpperBrandModelMi == false);
            dto.Model = (from c in value4
                         select new BrandModelDTO 
                         {
                            BrandModelID = c.BrandModelID,
                            BrandModelName = c.BrandModelName
                         }).ToList();

            var value5 = _assetGroupDal.GetAll(x => x.isActive == true);
            dto.AssetGroup = (from g in value5
                              select new AssetGroupDTO 
                              {
                                AssetGroupID = g.AssetGroupID,
                                AssetGroupName = g.AssetGroupName
                              }).ToList();

            return dto;
        }       
    }
}
