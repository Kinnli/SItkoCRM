using System;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SitkoCRM.Components.API;
using SitkoCRM.Components.Repository;
using SitkoCRM.Components.Storage;
using SitkoCRM.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace SitkoCRM
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
            services.AddDbContext<CRMContainer>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "MyApi", Version = "v1"}); });
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo
                .File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();

            // register repositories
            
            services.Scan(s =>
                s.FromAssemblyOf<Startup>().AddClasses(classes => classes.AssignableTo<IRepository>())
                    .AsSelfWithInterfaces().WithScopedLifetime());
            services.Scan(s =>
                s.FromAssemblyOf<Startup>().AddClasses(classes => classes.AssignableTo(typeof(RepositoryContext<,,>)))
                    .AsSelfWithInterfaces().WithScopedLifetime());
            services.Scan(s =>
                s.FromAssemblyOf<Startup>().AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
                    .AsSelfWithInterfaces().WithScopedLifetime());
            
            // register api entities
            
            services.Scan(s =>
                s.FromAssemblyOf<Startup>().AddClasses(classes => classes.AssignableTo(typeof(RestModel<,>)))
                    .AsSelf().WithTransientLifetime());
            services.AddScoped<ApiControllerContext>();
            services.AddScoped(typeof(ApiControllerContext<,>));
            
            // configure and register storage 
            
            services.Configure<S3StorageOptions>(o =>
            {
                o.PublicUri = new Uri("http://localhost:9876/crm");
                o.Server = new Uri("http://localhost:9876");
                o.Bucket = "crm";
                o.AccessKey = "bla";
                o.SecretKey = "bla";
            });
            services.AddSingleton<IStorage, S3Storage>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            app.UseMvc();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment()) spa.UseReactDevelopmentServer("start");
            });
        }
    }
}
