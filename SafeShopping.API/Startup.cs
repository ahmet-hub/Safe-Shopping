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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SafeShopping.Service.Security.Token;
using SafeShopping.Service.Services.Authentication;
using SafeShopping.Core.DataAccess;

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
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IUserCheckService), typeof(MernisServiceAdapter));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IAuthenticationService), typeof(AuthenticationService));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(ITokenHandle), typeof(TokenHandle));
            services.AddScoped(typeof(ITransactionService), typeof(TransactionService));
            services.AddScoped(typeof(ITransactionRepository), typeof(TransactionRepository));
            services.AddScoped(typeof(ILoadMoneyRepository), typeof(LoadMoneyRepository));
            services.AddScoped(typeof(ILoadMoneyService), typeof(LoadMoneyService));

            var securityKey = SignHandle.GetSecurityKey("mysecuritykeymysecuritykeymysecuritykeyahmet");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerOptions =>
            {
                JwtBearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {

                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "www.safeshopping.com",
                    ValidAudience = "www.safeshopping.com",
                    IssuerSigningKey = securityKey,
                    ClockSkew = TimeSpan.Zero

                };
            });
            services.AddDbContext<SafeShoppingContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o => o.MigrationsAssembly("SafeShopping.DataAccess"));
                services.AddScoped<IUnitOfWork, UnitOfWork>();
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
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
