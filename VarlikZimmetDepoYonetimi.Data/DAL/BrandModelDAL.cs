using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.Core.Models.Entities;
using VarlikZimmetDepoYonetimi.Data.DB;
using VarlikZimmetDepoYonetimi.Data.Repositories;

namespace VarlikZimmetDepoYonetimi.Data.DAL
{
    public class BrandModelDAL : EfEntityRepository<BrandModel, AssetStoreManagmentContext>, IBrandModelDAL
    {
        // markaya göre model getirme metodu yazılacak
    }
}
