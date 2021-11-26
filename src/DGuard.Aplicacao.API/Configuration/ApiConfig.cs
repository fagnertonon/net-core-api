using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DGuard.WebAPI.Core.Identidade;
using DGuard.Aplicacao.API.Data;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace DGuard.Aplicacao.API.Configuration
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            services.AddDbContext<ApplicationContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });
        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler(
                           options =>
                           {
                               options.Run(
                                   async context =>
                                   {
                                       context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                       context.Response.ContentType = "text/html";
                                       var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                                       if (null != exceptionObject)
                                       {
                                           var errorMessage = $"<b>Error: {exceptionObject.Error.Message} </b> { exceptionObject.Error.StackTrace}";
                                           await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
                                       }
                                   });
                           }
                       );

            app.UseRouting();

            app.UseCors("Total");

            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}