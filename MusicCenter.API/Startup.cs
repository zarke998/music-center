using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicCenter.API.Core;
using MusicCenter.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MusicCenter.Implementation.Queries.ProductQueries;
using MusicCenter.Application.Queries;
using MusicCenter.Application;
using MusicCenter.Implementation.Loggers;
using MusicCenter.Application.Email;
using MusicCenter.Implementation.Email;

namespace MusicCenter.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings();

            Configuration.Bind(appSettings);
            services.AddAutoMapper(typeof(EfGetProductsQuery).Assembly);
            services.AddTransient<MusicCenterDbContext>();
            services.AddTransient<DbSeeder>();
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddTransient<UseCaseExecutor>();
            services.AddUseCases();
            services.AddValidators();
            services.AddJwt(appSettings);
            services.AddSwagger();
            services.AddTransient<IEmailSender>(provider => new SmtpEmailSender(appSettings.AppEmail, appSettings.AppPassword));

            services.AddHttpContextAccessor();
            services.AddApplicationActor();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });

            app.UseRouting();
            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
