using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Provider;

namespace VarlikZimmetDepoYonetimi.UI
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
            services.AddControllersWithViews();
            // proje bazlý authentication
            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //});

            // asagýdaki endpoinleri geç bunu dinle
            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);


            services.AddHttpClient<TokenProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<AssetProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<AssetActionProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<AssetBarcodeProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<AssetGroupProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<AssetPriceProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<AssetTypeProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<BrandModelProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<CommentProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<UnitProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<AssetStatusProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<GetAssetTableProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<CustomerProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<AssetActionOptionsProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<PersonnelProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<CompanyProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });
            services.AddHttpClient<AssetOwnerProvider>(option =>
            {
                option.BaseAddress = new Uri(Configuration["myBaseAdress"]);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //    endpoints.MapControllerRoute(
            //    name: "areas",
            //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            //  );
            //});

            // mvc'ye ait route, 
            app.UseMvc(route =>
            {
                route.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                route.MapRoute(
                name: "areas",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}" //     admin/home/index        zimmet/home/index       home/index
              );
            });
        }
    }
}
