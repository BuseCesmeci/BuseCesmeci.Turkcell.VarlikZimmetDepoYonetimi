using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.API.Models.Filters;
using VarlikZimmetDepoYonetimi.Core.IRepositories;
using VarlikZimmetDepoYonetimi.Data.DAL;
using VarlikZimmetDepoYonetimi.Data.DB;
using VarlikZimmetDepoYonetimi.Data.Repositories;
using VarlikZimmetDepoYonetimi.Service.Mapping;

namespace VarlikZimmetDepoYonetimi.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value);          
            services.AddDbContext<AssetStoreManagmentContext>(options=> options.UseSqlServer($"Data Source=.; DataBase = AssetStoreManagment; Integrated Security = True"));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VarlikZimmetDepoYonetimi.API", Version = "v1" });
            });
            services.AddCors();
            services.AddScoped<IAuthRepository, AuthRepository>();
           // services.AddScoped<IEntityRepository, EfEntityRepository>();
            services.AddScoped<IAssetDAL, AssetDAL>();
            services.AddScoped<IAssetActionDAL, AssetActionDAL>();
            services.AddScoped<IPersonnelDAL, PersonelDAL>();
            services.AddScoped<ICurrencyDAL, CurrencyDAL>();
            services.AddScoped<IBrandModelDAL, BrandModelDAL>();
            services.AddScoped<IAssetTypeDAL, AssetTypeDAL>();
            services.AddScoped<IAssetActionOptionsDAL, AssetActionOptionsDAL>();
            services.AddScoped<IActionStatusDAL, ActionStatusDAL>();
            services.AddScoped<IAssetBarcodeDAL, AssetBarcodeDAL>();
            services.AddScoped<IAssetCustomerDAL, AssetCustomerDAL>();
            services.AddScoped<IAssetGroupDAL, AssetGroupDAL>();
            services.AddScoped<IAssetOwnerDAL, AssetOwnerDAL>();
            services.AddScoped<IAssetStatusDAL, AssetStatusDAL>();
            services.AddScoped<ICommentDAL, CommentDAL>();
            services.AddScoped<ICurrencyDAL, CurrencyDAL>();
            services.AddScoped<ICustomerDAL, CustomerDAL>();
            services.AddScoped<IOwnerTypeDAL, OwnerTypeDAL>();
            services.AddScoped<IPriceDAL, PriceDAL>();
            services.AddScoped<IStatuDAL, StatuDAL>();
            services.AddScoped<IUnitDAL, UnitDAL>();
            services.AddScoped<IPersonnelDAL, PersonelDAL>();
            services.AddScoped<ICompanyDAL, CompanyDAL>();
            services.AddHttpClient();
            services.AddScoped<NotFoundFilter>();       
            services.AddAutoMapper(typeof(IMapProfile));
            

            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VarlikZimmetDepoYonetimi.API v1"));
            }
            
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseCors(builder => builder.WithOrigins("http://localhost:31994").AllowAnyHeader());
            app.UseCors(builder => builder.WithOrigins("http://localhost:5002").AllowAnyHeader());
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
