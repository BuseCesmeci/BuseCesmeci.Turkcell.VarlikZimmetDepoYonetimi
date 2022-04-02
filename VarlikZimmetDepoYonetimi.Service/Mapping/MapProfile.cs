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

            CreateMap<AssetBarcode, AssetBarcodeDTO>();
            CreateMap<AssetBarcodeDTO, AssetBarcode>();

            CreateMap<AssetStatus, AssetStatusDTO>();
            CreateMap<AssetStatusDTO, AssetStatus>();

            CreateMap<Price, PriceDTO>();
            CreateMap<PriceDTO, Price>();

            CreateMap<Unit, UnitDTO>();
            CreateMap<UnitDTO, Unit>();

            CreateMap<Statu, StatuDTO>();
            CreateMap<StatuDTO, Statu>();

            CreateMap<AssetOwner, AssetOwnerDTO>();
            CreateMap<AssetOwnerDTO, AssetOwner>();

            CreateMap<OwnerType, OwnerTypeDTO>();
            CreateMap<OwnerTypeDTO, OwnerType>();

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<AssetCustomer, AssetCustomerDTO>();
            CreateMap<AssetCustomerDTO, AssetCustomer>();

            CreateMap<Comment, CommentDTO>();
            CreateMap<CommentDTO, Comment>();           

            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();

            CreateMap<AssetGroup, AssetGroupDTO>();
            CreateMap<AssetGroupDTO, AssetGroup>();
        }
    }
}
