using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SafeShopping.Core.Service;
using SafeShopping.Core.UnitOfWork;
using SafeShopping.DataAccess.EntityFramework;
using SafeShopping.DataAccess.EntityFramework.UnitOfWork;
using SafeShopping.Service.Abstract;
using SafeShopping.Service.Services;
using AutoMapper;
using SafeShopping.Core.Entitiy.Concrete;
using SafeShopping.Service.Adapter;

namespace SafeShopping.API
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

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped(typeof(Core.DataAccess.IEntityRepositoy<>), typeof(EfEntityRepositoryBase<>));
            services.AddScoped(typeof(IAccountService), typeof(AccountService));
            services.AddScoped(typeof(IAccountCheckService), typeof(MernisServiceAdapter));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddControllers();
         
            services.AddDbContext<SafeShoppingContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(),o=>o.MigrationsAssembly("SafeShopping.DataAccess"));
                services.AddScoped<IUnitOfWork, UnitOfWork>();
            });

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
