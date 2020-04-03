using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBContext.Repository;
using Domain.Entity;
using Domain.Interfaces;
using Domain.Provider;
using MeuPortfolio.PortfolioManagement.Infra.SQL.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiTenant
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
            services.AddHttpContextAccessor();

            services.AddDbContext<TenantContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-H0F1K97;Database=examples;Trusted_Connection=True;MultipleActiveResultSets=true");
            });

            services.AddTransient(serviceProvider =>
            {
                var contextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
                if (contextAccessor != null)
                    if (contextAccessor.HttpContext.Request.Headers.TryGetValue("x-tenant-id", out var tenantHeaderValue) && Guid.TryParse(tenantHeaderValue, out var tenantId))
                        return new TenantProvider(tenantId);

                throw new ArgumentNullException("x-tenant-id", "Empresa não informada");
            });

            services.AddTransient<TenantRepository, TenantRepository>();
            services.AddTransient<PortfolioRepository, PortfolioRepository>();

            services.AddControllers();
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
