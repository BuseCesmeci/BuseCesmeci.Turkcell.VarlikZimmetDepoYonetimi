using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.Core.DTOs;
using VarlikZimmetDepoYonetimi.Core.Models.Entities;
using VarlikZimmetDepoYonetimi.Data.DB;
using VarlikZimmetDepoYonetimi.Data.Repositories;

namespace VarlikZimmetDepoYonetimi.Data.DAL
{
    public class AssetDAL : EfEntityRepository<Asset, AssetStoreManagmentContext>, IAssetDAL
    {
        AssetStoreManagmentContext context = new AssetStoreManagmentContext();

        public List<GetAssetTableDTO> GetAssetList()
        {
            var q = (from i in context.Asset
                     where i.isActive == true
                     join p in context.Price on i.AssetID equals p.AssetID
                     join b in context.AssetBarcode on i.AssetID equals b.AssetID
                     join t in context.AssetType on i.AssetTypeID equals t.AssetTypeID
                     join ag in context.AssetGroup on i.AssetGroupID equals ag.AssetGroupID                     
                     join br in context.BrandModel on i.BrandModelID equals br.BrandModelID
                     join m in context.BrandModel on i.BrandModelID equals m.BrandModelID
                    // group new { i } by new { i, b, t, ag, p, br, m } into grb
                     select new GetAssetTableDTO
                     {
                         RegistrationNumber = i.RegistrationNumber,
                         Barcode = b.Barcode,
                         AssetTypeName = t.AssetTypeName,
                         AssetGroupName = ag.AssetGroupName,
                         AssetPrice = p.AssetPrice,
                         BrandModelName = br.BrandModelName,

                     }).ToList();

            return q;
        }
    }
}
