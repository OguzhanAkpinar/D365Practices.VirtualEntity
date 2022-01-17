using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtualEntityODataSource.Data;
using VirtualEntityODataSource.Helpers;
using VirtualEntityODataSource.Repositories;

namespace VirtualEntityODataSource
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<VirtualEntityDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("VirtualEntityDbConnection"));
            });
            services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata", ODataHelper.GetEdmModel())
                                    .Select().Expand().Filter().OrderBy().SetMaxTop(100).Count());
            services.AddScoped(typeof(IODataRepository<>), typeof(ODataRepository<>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseODataRouteDebug();
            app.UseODataQueryRequest();
            app.UseODataBatching();
            app.UseRouting();
            app.Use(next => context =>
            {
                var endpoint = context.GetEndpoint();
                if (endpoint == null)
                {
                    return next(context);
                }

                return next(context);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
