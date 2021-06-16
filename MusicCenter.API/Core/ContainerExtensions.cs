using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MusicCenter.Application;
using MusicCenter.Application.Commands.BrandCommands;
using MusicCenter.Application.Commands.CategoryCommands;
using MusicCenter.Application.Commands.OrderCommands;
using MusicCenter.Application.Commands.ProductCommands;
using MusicCenter.Application.Commands.UserCartProductCommands;
using MusicCenter.Application.Commands.UserCommands;
using MusicCenter.Application.Commands.UserUseCaseCommands;
using MusicCenter.Application.Queries.BrandQueries;
using MusicCenter.Application.Queries.CategoryQueries;
using MusicCenter.Application.Queries.OrderQueries;
using MusicCenter.Application.Queries.ProductQueries;
using MusicCenter.Application.Queries.UseCaseLogQueries;
using MusicCenter.Application.Queries.UserQueries;
using MusicCenter.Application.Queries.UserUseCaseQueries;
using MusicCenter.Application.Queries.UserUseCasesQueries;
using MusicCenter.EfDataAccess;
using MusicCenter.Implementation.Commands.BrandCommands;
using MusicCenter.Implementation.Commands.CategoryCommands;
using MusicCenter.Implementation.Commands.OrderCommands;
using MusicCenter.Implementation.Commands.ProductCommands;
using MusicCenter.Implementation.Commands.UserCartProductCommands;
using MusicCenter.Implementation.Commands.UserCommands;
using MusicCenter.Implementation.Commands.UserUseCaseCommands;
using MusicCenter.Implementation.Queries.BrandQueries;
using MusicCenter.Implementation.Queries.CategoryQueries;
using MusicCenter.Implementation.Queries.OrderQueries;
using MusicCenter.Implementation.Queries.ProductQueries;
using MusicCenter.Implementation.Queries.UseCaseLogQueries;
using MusicCenter.Implementation.Queries.UserQueries;
using MusicCenter.Implementation.Queries.UserUseCaseQueries;
using MusicCenter.Implementation.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
            services.AddTransient<IUpdateBrandCommand, EfUpdateBrandCommand>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();
            #endregion

            #region Category Use Cases
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
            services.AddTransient<IGetSingleCategoryQuery, EfGetSingleCategoryQuery>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            #endregion

            #region User Use Cases
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetSingleUserQuery, EfGetSingleUserQuery>();
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            #endregion

            #region UserUseCase use cases
            services.AddTransient<ICreateUserUseCaseCommand, EfCreateUserUseCaseCommand>();
            services.AddTransient<IDeleteUserUseCaseCommand, EfDeleteUserUseCaseCommand>();
            #endregion

            #region UserCartProduct use cases
            services.AddTransient<ICreateUserCartProductCommand, EfCreateUserCartProductCommand>();
            services.AddTransient<IDeleteUserCartProductCommand, EfDeleteUserCartProductCommand>();
            services.AddTransient<IGetUserUseCasesQuery, EfGetUserUseCasesQuery>();
            services.AddTransient<IGetSingleUserUseCaseQuery, EfGetSingleUserUseCaseQuery>();
            #endregion

            #region UseCaseLog use cases
            services.AddTransient<IGetUseCaseLogsQuery, EfGetUseCaseLogsQuery>();
            #endregion

            #region Order use cases
            services.AddTransient<ICreateOrderCommand, EfCreateOrderCommand>();
            services.AddTransient<IGetOrdersQuery, EfGetOrdersQuery>();
            services.AddTransient<IGetSingleOrderQuery, EfGetSingleOrderQuery>();
            #endregion
        }
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateProductValidator>();
            services.AddTransient<UpdateProductValidator>();

            services.AddTransient<CreateBrandValidator>();
            services.AddTransient<UpdateBrandValidator>();

            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();

            services.AddTransient<CreateUserValidator>();
            services.AddTransient<UpdateUserValidator>();

            services.AddTransient<CreateUserUseCaseValidator>();

            services.AddTransient<CreateUserCartProductValidator>();

            services.AddTransient<CreateOrderValidator>();
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
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MusicCenter", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                    }
                });
            });
        }
    }
}
