using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExampleCRUD.WebService.API
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
            services.AddControllers().AddNewtonsoftJson();

            services.AddCors(options =>
            {
                options.AddPolicy("Default", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    //builder.AllowCredentials();
                    builder.Build();
                });
            });

            services.AddScoped(typeof(Domain.IDbContexts.IDbContextBase),
                dbContextBase =>
                {
                    return
                    new Infra.Data.DapperData.Contexts.DbContextBase(
                        Configuration,
                        SqlClientFactory.Instance);
                });

            services.AddScoped(typeof(Domain.IUnitOfWords.IUnitOfWord), typeof(Infra.Data.DapperData.UnitOfWords.UnitOfWork));

            services.AddScoped(typeof(Domain.IRepositories.IUserRepository), typeof(Infra.Data.DapperData.Repositories.UserRepository));
            services.AddScoped(typeof(Domain.IServices.IUserService), typeof(Domain.Services.UserService));
            services.AddScoped(typeof(Application.IServices.IUserAppService), typeof(Application.Services.UserAppService));
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

            app.UseCors("Default");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
