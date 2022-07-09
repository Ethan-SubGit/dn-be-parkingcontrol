using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Parkgin.Server.Api.HubConfig;
using Parkgin.Server.Api.Service;
using Parkgin.Server.Application.Infrastructure;

using Parking.Server.Infrastructure.Models;
using Parking.Server.Infrastructure.Procedure;
using Parking.Server.Infrastructure.Repositories;
using Parking.Server.Infrastructure.SeedWork;
using Parkintg.Server.Application.Service;
using Parkintg.Server.Application.Services;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using CacheControlHeaderValue = Microsoft.Net.Http.Headers.CacheControlHeaderValue;

namespace Parkgin.Server.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            //Configuration = configuration;

        }

        //public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        //        .AddEnvironmentVariables();
        //    Configuration = builder.Build();
        //}

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region ## add jwt
            //services.AddCors();
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSignalR();

            //Net Core 3.0 possible object cycle was detected which is not supported
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);


            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuditLogService, AuditService>();
            services.AddScoped<IParkingManagerService, ParkingManagerService>();
            services.AddScoped<IParkingTicketService, ParkingTicketService>();
            #endregion


            services.AddSwaggerGen(c =>
            {
                #region # ¡÷ºÆ
                /*
                        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                        {
                            Description =
                "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                            Name = "Authorization",
                            In = ParameterLocation.Header,
                            Type = SecuritySchemeType.ApiKey,
                            Scheme = "Bearer"
                        });

                        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                        {
                            {
                                new OpenApiSecurityScheme
                                {
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
                        */
                #endregion

                c.AddSecurityDefinition("Bearer", //Name the security scheme
                new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
                    Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Parking Project",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "mobilepro@instarco.kr",
                        Email = string.Empty,
                        Url = new Uri("http://instarco.kr"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddResponseCaching();
            //services.AddTransient<ISP_Code_Projection, SP_Code_Projection>();
            //services.AddTransient<ITParkingLotBasicInfoRepository, TParkingLotBasicInfoRepository>();
            //services.AddTransient<ITCodeMasterRepository, TCodeMasterRepository>();
            services.AddScoped<ISP_Code_Projection, SP_Code_Projection>();
            services.AddScoped<IParkingLotBasicInfoRepository, ParkingLotBasicInfoRepository>();
            services.AddScoped<ITCodeMasterRepository, TCodeMasterRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ParkingIntegratedControlCenterContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        }

        //public IServiceProvider ConfigureService(IServiceCollection services)
        //{

        //    var builder = new ContainerBuilder();

        //    builder.RegisterType<SP_TCode>().As<ISP_TCode>();
        //    builder.Populate(services);
        //    var container = builder.Build();
        //    return container.Resolve<IServiceProvider>();
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseHttpsRedirection();



            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();
            
            //var pathBase = Configuration["PATH_BASE"];

            //if (!string.IsNullOrEmpty(pathBase))
            //{
            //    loggerFactory.CreateLogger<Startup>().LogDebug("Using PATH BASE '{pathBase}'", pathBase);
            //    app.UsePathBase(pathBase);
            //}
            //app.UseCors("CorsPolicy");


            //app.UseRouting();
            //ConfigureEventBus(app);
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


            #region ## cacheing
            //app.UseResponseCaching();
            //app.Use(async (context, next) =>
            //{
            //    context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
            //    {
            //        Public = true,
            //        MaxAge = TimeSpan.FromSeconds(10)
            //    };
            //    context.Response.Headers[HeaderNames.Vary] = new string[] { "Accept-Encoding" };

            //    await next();
            //}); 
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRDataHub>("/SignalRDataHub");
            });
        }



        protected virtual void ConfigureEventBus(IApplicationBuilder app)
        {
            //var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            //eventBus.Subscribe<OrderStatusChangedToAwaitingValidationIntegrationEvent, OrderStatusChangedToAwaitingValidationIntegrationEventHandler>();
            //eventBus.Subscribe<OrderStatusChangedToPaidIntegrationEvent, OrderStatusChangedToPaidIntegrationEventHandler>();
        }
    }
}
