using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.Core.Models.Entities;

namespace VarlikZimmetDepoYonetimi.Data.DB
{
    public class AssetStoreManagmentContext : DbContext
    {
        public AssetStoreManagmentContext()
        {

        }

        public AssetStoreManagmentContext(DbContextOptions options) :base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;DataBase=AssetStoreManagment;Integrated Security=True");
        }

        public DbSet<ActionStatus> ActionStatus { get; set; }
        public DbSet<AppPage> AppPage { get; set; }
        public DbSet<AppPageProcessClaim> AppPageProcessClaim { get; set; }
        public DbSet<Asset> Asset { get; set; }
        public DbSet<AssetAction> AssetAction { get; set; }
        public DbSet<AssetBarcode> AssetBarcode { get; set; }
        public DbSet<AssetCustomer> AssetCustomer { get; set; }
        public DbSet<AssetGroup> AssetGroup { get; set; }
        public DbSet<AssetOwner> AssetOwner { get; set; }
        public DbSet<AssetType> AssetType { get; set; }
        public DbSet<AssetWithoutBarcode> AssetWithoutBarcode { get; set; }
        public DbSet<BrandModel> BrandModel { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Communication> Communication { get; set; }
        public DbSet<CommunicationType> CommunicationType { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<LoginInfo> LoginInfo { get; set; }
        public DbSet<OwnerType> OwnerType { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<PersonnelLoginInfo> PersonnelLoginInfo { get; set; }
        public DbSet<PersonnelPersonnelTeam> PersonnelPersonnelTeam { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<ProcessClaim> ProcessClaim { get; set; }
        public DbSet<RolePersonnel> RolePersonnel { get; set; }
        public DbSet<Statu> Statu { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}
