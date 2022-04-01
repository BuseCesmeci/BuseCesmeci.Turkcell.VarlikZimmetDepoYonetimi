using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.Core.DTOs;
using VarlikZimmetDepoYonetimi.Core.Models.Entities;

namespace VarlikZimmetDepoYonetimi.Service.Mapping
{
    public class MapProfile : Profile , IMapProfile
    {

        public MapProfile()
        {
            CreateMap<Asset, AssetDTO>();
            CreateMap<AssetDTO, Asset>();

            CreateMap<AssetAction, AssetActionDTO>();
            CreateMap<AssetActionDTO, AssetAction>();

            CreateMap<Personnel, PersonnelDTO>();
            CreateMap<PersonnelDTO, Personnel>();

            CreateMap<Currency, CurrencyDTO>();
            CreateMap<CurrencyDTO, Currency>();

            CreateMap<AssetType, AssetTypeDTO>();
            CreateMap<AssetTypeDTO, AssetType>();

            CreateMap<BrandModel, BrandModelDTO>();
            CreateMap<BrandModelDTO, BrandModel>();


        }
    }
}
