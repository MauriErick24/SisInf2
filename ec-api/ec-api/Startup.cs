using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using core.Communication;
using core.Services;
using interfaces.Repositories;
using interfaces.Services;
using models;
using persistence.Contexts;
using persistence.Repositories;


namespace ec_api
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

            services.AddControllers();
            services.AddCors(options => options.AddPolicy("AppPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ec_api", Version = "v1" });
            });
            string connectionStr = Configuration.GetConnectionString("AppContextConnectionString");
            services.AddDbContextPool<AppDbContext>(
                options => options.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr))
            );

            services.AddScoped<IRepository<Dessert>, DessertRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDessertService<AppResponse<Dessert>>, DessertService>();
            services.AddScoped<IUserService<AppResponse<UserAuthenticated>>, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ec_api v1"));
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
