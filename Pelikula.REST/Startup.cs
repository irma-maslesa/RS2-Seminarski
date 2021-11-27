using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Pelikula.API.Api;
using Pelikula.DAO;
using Pelikula.CORE.Impl;
using System;
using Pelikula.CORE.Validation;
using Pelikula.API.Validation;
using Pelikula.CORE.Filter;
using Microsoft.AspNetCore.Authentication;
using Pelikula.REST.Security;

namespace Pelikula.REST
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

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KinoCentar API", Version = "v1" });

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers(x =>
            {
                x.Filters.Add<ExceptionFilterAttribute>();
            });

            services.AddScoped<IZanrValidator, ZanrValidatorImpl>();
            services.AddScoped<IZanrService, ZanrServiceImpl>();

            services.AddScoped<ITipKorisnikaValidator, TipKorisnikaValidatorImpl>();
            services.AddScoped<ITipKorisnikaService, TipKorisnikaServiceImpl>();

            services.AddScoped<IKorisnikValidator, KorisnikValidatorImpl>();
            services.AddScoped<IKorisnikService, KorisnikServiceImpl>();

            services.AddScoped<IJedinicaMjereValidator, JedinicaMjereValidatorImpl>();
            services.AddScoped<IJedinicaMjereService, JedinicaMjereServiceImpl>();

            services.AddScoped<IObavijestValidator, ObavijestValidatorImpl>();
            services.AddScoped<IObavijestService, ObavijestServiceImpl>();

            services.AddScoped<IAnketaValidator, AnketaValidatorImpl>();
            services.AddScoped<IAnketaService, AnketaServiceImpl>();

            services.AddScoped<IArtikalValidator, ArtikalValidatorImpl>();
            services.AddScoped<IArtikalService, ArtikalServiceImpl>();

            services.AddScoped<IFilmskaLicnostValidator, FilmskaLicnostValidatorImpl>();
            services.AddScoped<IFilmskaLicnostService, FilmskaLicnostServiceImpl>();

            services.AddScoped<IFilmValidator, FilmValidatorImpl>();
            services.AddScoped<IFilmService, FilmServiceImpl>();

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "Pelikula API");
            });
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
