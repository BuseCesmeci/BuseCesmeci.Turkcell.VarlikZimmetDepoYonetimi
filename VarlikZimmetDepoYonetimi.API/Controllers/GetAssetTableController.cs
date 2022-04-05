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
    public class GetAssetTableController : ControllerBase
    {
        IAssetDAL _assetDal;
        IBrandModelDAL _brandModelDal;
        IAssetTypeDAL _assetTypeDal;
        IPriceDAL _priceDal;
        IAssetGroupDAL _assetGroupDal;
        IAssetBarcodeDAL _barcodeDal;
        IMapper _mapper;

        public GetAssetTableController(IAssetDAL assetDAL, IBrandModelDAL brandModelDAL, IAssetTypeDAL typeDAL,
            IPriceDAL priceDAL, IAssetGroupDAL groupDAL, IAssetBarcodeDAL barcodeDAL, IMapper mapper)
        {
            _assetDal = assetDAL;
            _brandModelDal = brandModelDAL;
            _assetTypeDal = typeDAL;
            _priceDal = priceDAL;
            _assetGroupDal = groupDAL;
            _barcodeDal = barcodeDAL;

        }
        [HttpGet]
        [Route("~/api/getassettable")]       
        public List<GetAssetTableDTO> GetTableAsync()
        {
            var value =  _assetDal.GetAssetList();
            GetAssetTableDTO dto = new GetAssetTableDTO();
            return value;
        }
    }
}
