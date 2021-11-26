using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DGuard.Core.Mediator;
using DGuard.WebAPI.Core.Usuario;
using DGuard.Aplicacao.API.Application.ServerCommand;
using DGuard.Aplicacao.API.Data.Repository;
using DGuard.Aplicacao.API.Models;
using DGuard.Aplicacao.API.Data;

namespace DGuard.Aplicacao.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<CreateServerCommand, ValidationResult>, ServerCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteServerCommand, ValidationResult>, ServerCommandHandler>();
                        
            services.AddScoped<IServerRepository, ServerRepository>();

            services.AddScoped<ApplicationContext>();
        }
    }
}