using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using PSW.GMS.Service;
using PSW.GMS.Service.AutoMapper;

using PSW.GMS.Data;
using PSW.GMS.Data.Sql;

using PSW.Lib.Consul;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using PSW.Common.Crypto;
using System.Security.Cryptography;
using PSW.RabbitMq;
using PSW.GMS.RabbitMq;
using PSW.Lib.Logs;
using PSW.Lib.WorkFlow.Configurations.Options;
using System.Collections.Generic;
using PSW.LogDB;
using PSW.LogDB.Configurations.Options;

namespace PSW.GMS.Api
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
            string salt = Environment.GetEnvironmentVariable("ENCRYPTION_SALT");
            string password = Environment.GetEnvironmentVariable("ENCRYPTION_PASSWORD");

            if (string.IsNullOrWhiteSpace(salt) || string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Please provide salt and password for Crypto Algorithm in Environment Variable");
            }

            services.AddSingleton<IAppSettingsProcessor>(_ => new AppSettingsDecrypter<AesManaged>(_.GetService<IConfiguration>(),
                password,
                salt));

            services.AddScoped<ICryptoAlgorithm>(x =>
            {
                return new CryptoFactory().Create<AesManaged>(password, salt);
            });
            ConnectionList.Instance.Init();
            services.AddHostedService<GMSQueueWorker>();
            services.AddHostedService<GMSRPCService>();
            services.AddControllers()
                   .AddJsonOptions(options =>
                   {
                       options.JsonSerializerOptions.IgnoreNullValues = true;
                   });

            services.AddTransient<IGmsSecureService, GmsSecureService>();
            services.AddTransient<IGmsOpenService, GmsOpenService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Auto Mapper Profiles 
            services.AddAutoMapper(
                typeof(DTOToEntityMappingProfile),
                typeof(EntityToDTOMappingProfile)
            );




            services.AddSingleton<IEventBus, RabbitMqBus>(s =>
            {
                var lifetime = s.GetRequiredService<IHostApplicationLifetime>();
                return new RabbitMqBus(lifetime, Configuration);
            });

            //--- This Section is for Securing API (via IdentityServer) ---------------------------------------------
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = Environment.GetEnvironmentVariable("ASPNETCORE_IDENTITY_SERVER_ISSUER");
                options.ApiName = "auth";
                options.ApiSecret = "auth";
                options.RequireHttpsMetadata = false;
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("OnAuthenticationFailed: " +
                            context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("OnTokenValidated: " +
                            context.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
            });

            var allowedWeBoCIds = new List<string>{
               "ADWEBCY06",
               };

            var allowedGMSIds = new List<string>{
               "GMSPSQCA"
               };

            services.AddAuthorization(options =>
            {
                options.AddPolicy("authorizedUserPolicy", policyAdmin =>
                {
                    policyAdmin.RequireClaim("client_id", "psw.client.spa");
                });

                options.AddPolicy("authWeBoCPolicy", policyAdmin =>
               {
                   policyAdmin.RequireClaim("client_id", allowedWeBoCIds);
               });

                options.AddPolicy("authGMSPolicy", policyAdmin =>
               {
                   policyAdmin.RequireClaim("client_id", allowedGMSIds);
               });
            });


            services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.SetIsOriginAllowed(_ => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
                });

            services.AddConsul(Configuration);
            services.AddHealthChecks();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAppSettingsProcessor settingsDecrypter,
            IUnitOfWork unitOfWork, IEventBus eventBus, IGmsSecureService gmsSecureService, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UsePSWLogger();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            string UseConsulDev = Configuration.GetSection("UseConsulDev").Value;

            if (UseConsulDev.ToLower() == "true")
            {
                app.UseConsul(lifetime);
            }

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            Configuration.GetSection(LogDBConnectionStringsOptions.ConnectionStrings).Bind(LogDBConnectionStringsOptions.Instance);
            // Pass Configuarions To LibWorkflow  
            Configuration.GetSection(ConnectionStringsOptions.ConnectionStrings).Bind(ConnectionStringsOptions.Instance);

        }
    }
}
