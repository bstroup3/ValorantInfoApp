using MudBlazor.Services;
using MediatR;
using System.Reflection;
using ValorantInfoApp.Shared;
using ValorantInfoApp.Features.Pages;

namespace ValorantInfoApp;

public static class DependencyInjectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMudServices();

            // Register MediatR services
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AgentRequestHandler>());

            services.AddSingleton<IValorantApiService, ValorantApiService>();
            services.AddSingleton<ValorantApiSettings>();

            services.AddHttpClient(); // Register HttpClient
        }
    }
