using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLinksAPI.Data;
using MyLinksAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace MyLinksAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public string MyAllowSpecificOrigins { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: MyAllowSpecificOrigins,
            //                      builder =>
            //                      {
            //                          builder.WithOrigins("http://localhost:5500");
            //                      });
            //});
            //services.AddCors();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
            }));

            services.AddControllers();

            services.AddSwaggerGen();

            services.AddDbContextPool<MyLinkDataContext>(options =>
            {
                options.UseSqlServer(Configuration["MyLinkDataContext_ConnectionString"],
                    provider => provider.CommandTimeout(
                        string.IsNullOrWhiteSpace(Configuration["MyLinkDataContext_CommandTimeout"])
                        ?
                        90 : Convert.ToInt32(Configuration["MyLinkDataContext_CommandTimeout"])
                    ));
            },
                string.IsNullOrWhiteSpace(Configuration["MyLinkDataContext_PoolSize"])
                ?
                128 : Convert.ToInt32(Configuration["MyLinkDataContext_PoolSize"])
            );

            services.AddScoped<IMyLinksRepository, MyLinksRepository>();
            services.AddScoped<IExtranetUserRepository, ExtranetUserRepository>();
            services.AddScoped<IMyLinksService, MyLinksService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            }); 
            
            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors("MyPolicy");
            app.UseCors(
               options => options.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()
           );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
