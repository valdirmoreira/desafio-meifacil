using AutoMapper;
using FluentValidation.AspNetCore;
using MeiFacil.Payment.Infrastructure.CrossCutting.Filter;
using MeiFacil.Payment.Infrastructure.CrossCutting.IoC;
using MeiFacil.Payment.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace MeiFacil.Payment.Services.Api
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
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddFluentValidation();

            services.AddDbContext<PaymentContext>(options => options.UseInMemoryDatabase(databaseName: "PaymentApi"));
            services.AddAutoMapper(typeof(Startup));
            Application.AutoMapper.AutoMapperConfig.RegisterMappings();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "MeiFacil.Payment",
                    Description = "MeiFacil Payment API",
                    Contact = new Contact { Name = "Valdir Moreira", Email = "valdir.moreira.junior@gmail.com", Url = "https://www.meifacil.com/" },
                    License = new License { Name = "PRIVATE", Url = string.Empty }
                });
            });

            NativeInjectorBootStrapper.RegisterServices(services);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MeiFacil.Payment API");
                c.RoutePrefix = "docs";
            });

            app.UseHttpsRedirection();
            var option = new RewriteOptions();
            option.AddRedirect("^$", "docs");
            app.UseRewriter(option);

            app.UseMvc();
        }
    }
}
