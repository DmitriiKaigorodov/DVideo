using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DVideo.Core;
using DVideo.Core.FileStorage;
using DVideo.Core.Repositories;
using DVideo.Core.Services;
using DVideo.Persistent;
using DVideo.Persistent.LocalFileStorage;
using DVideo.Services;
using DVideo.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DVideo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IThumbnailsRepository, ThumbnailsRepository>();
            services.AddScoped<IVideoFilesRepository, VideoFilesRepository>();
            services.AddScoped<IVideosRepository, VideosRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public void ConfigureFileStorage(IServiceCollection services)
        {
            services.AddScoped<IFileStorage, LocalFileStorage>();
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            ConfigureRepositories(services);
            ConfigureFileStorage(services);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISignInService, SignInService>();
            services.Configure<FormOptions>(options
             => 
             {
                 options.ValueLengthLimit = int.MaxValue;
               options.MultipartBodyLengthLimit = long.MaxValue;
             });

            var videoSettingsSection = Configuration.GetSection("VideoSettings");
            var authenticationSettings = Configuration.GetSection("AuthenticationSettings");
            services.Configure<VideoFileSettings>(videoSettingsSection.GetSection("VideoFileSettings"));
            services.Configure<ThumbnailSettings>(videoSettingsSection.GetSection("ThumbnailSettings"));
            services.Configure<VideoSettings>(videoSettingsSection);
            services.Configure<AuthenticationSettings>(authenticationSettings);
            
            string connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<DvideoDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddAutoMapper();
            services.AddMvc();

            services.AddAuthentication().AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;

                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = authenticationSettings.GetValue<string>("Issuer"),
                    ValidAudience = authenticationSettings.GetValue<string>("Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.GetValue<string>("Secret")))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
