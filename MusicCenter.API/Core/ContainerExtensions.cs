using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MusicCenter.Application;
using MusicCenter.Application.Commands.BrandCommands;
using MusicCenter.Application.Commands.ProductCommands;
using MusicCenter.Application.Queries.BrandQueries;
using MusicCenter.Application.Queries.ProductQueries;
using MusicCenter.EfDataAccess;
using MusicCenter.Implementation.Commands.BrandCommands;
using MusicCenter.Implementation.Commands.ProductCommands;
using MusicCenter.Implementation.Queries.BrandQueries;
using MusicCenter.Implementation.Queries.ProductQueries;
using MusicCenter.Implementation.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            #region Product Use Cases
            services.AddTransient<IGetProductsQuery, EfGetProductsQuery>();
            services.AddTransient<IGetSingleProductQuery, EfGetSingleProductQuery>();
            services.AddTransient<ICreateProductCommand, EfCreateProductCommand>();
            services.AddTransient<IUpdateProductCommand, EfUpdateProductCommand>();
            services.AddTransient<IDeleteProductCommand, EfDeleteProductCommand>();
            #endregion

            #region Brand Use Cases
            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
            services.AddTransient<IGetSingleBrandQuery, EfGetSingleBrandQuery>();
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>();
            #endregion
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateProductValidator>();
            services.AddTransient<UpdateProductValidator>();

            services.AddTransient<CreateBrandValidator>();
        }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(provider =>
            {
                var httpAccessor = provider.GetService<IHttpContextAccessor>();

                var user = httpAccessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                return JsonConvert.DeserializeObject<JwtActor>(actorString);
            });
        }

        public static void AddJwt(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddTransient<JwtManager>(provider =>
            {
                var context = provider.GetService<MusicCenterDbContext>();

                return new JwtManager(context, appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions =>
            {
                jwtOptions.RequireHttpsMetadata = false;
                jwtOptions.SaveToken = true;
                jwtOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
