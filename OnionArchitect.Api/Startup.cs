﻿using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Core.ApplicationServices;
using Core.Domain.Contracts.ApplicationServices;
using Core.Domain.Contracts.Repositories;
using FluentValidation.AspNetCore;
using Framework.Web.Extensions;
using Framework.Web.Models;
using Infra.Common.Bootstrapper.StartupConfigurations;
using Infra.Common.Bootstrapper.StartupSettings;
using Infra.Data.SqlServer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace OnionArchitect.Api
{
    public class Startup
    {
        private readonly Settings settings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            settings = configuration.GetSection(nameof(Settings)).Get<Settings>();
            settings.ConnectionStrings= configuration.GetSection("ConnectionStrings").Get<ConnectionStringsSettings>();
            if (settings!=null&&settings.Swagger!=null)
            {
                settings.Swagger.XmlFile.Name = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                settings.Swagger.XmlFile.Path = Path.Combine(AppContext.BaseDirectory, settings.Swagger.XmlFile.Name);
                
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Settings>(Configuration.GetSection(nameof(Settings)));
           
            services.AddControllers(options =>
            {
                
                options.EnableEndpointRouting = false;

            })
           .ConfigureApiBehaviorOptions(options =>
           {
               options.InvalidModelStateResponseFactory = c =>
               {
                   ResponseMessage responseMessage = new ResponseMessage();
                   responseMessage.Title = "مقادیر ارسالی صحیح نیستند";
                   responseMessage.Descripton = c.ModelState.GetSingleLineErrorMessages();
                   return new BadRequestObjectResult(responseMessage);
               };
           })
           .AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblyContaining<Startup>(); });

            //services.AddCors();

            services.AddCustomUrlHelper();
            services.AddCustomDbContext(settings);
            services.AddCustomApiVersioning(settings);
            services.AddCustomSwagger(settings);
            services.AddCustomIdentity(settings);
            services.AddCustomJwtAuthentication(settings);
            services.AddAutoMapper(Assembly.GetAssembly(typeof(Startup)));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IArticleServices, ArticleServices>();
            
        }

        

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
         
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values Api V1");
            });
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
