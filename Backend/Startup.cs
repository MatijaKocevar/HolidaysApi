using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Holidays.Data;
using Microsoft.EntityFrameworkCore;

namespace Holidays
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
            //connect SqlServer using User secrets
            services.AddDbContext<HolidayContext>(opt => opt.UseSqlServer
            (
                Configuration.GetConnectionString("HolidayConnection")
            ));
            services.AddControllers();

            //dependency injection - New object per client request
            services.AddScoped<IHolidayRepo, SqlHolidayRepo>();

            //access database from different domain
            services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()));
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

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
