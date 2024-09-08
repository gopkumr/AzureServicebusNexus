using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using NexusExplorer.Domain.Models;
using NexusExplorer.Domain.Services.Abstractions;
using NexusExplorer.AzureServiceBus.Implementations;
using NexusExplorer.App.Services;
using NexusExplorerEvents = NexusExplorer.App.Services.NexusExplorerEvents;
using NexusExplorer.Mediator;

namespace NexusExplorer.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddSingleton<IServicebusAdminService, ServicebusAdminService>();
            builder.Services.AddSingleton<INexusExplorerEvents, NexusExplorerEvents>();
            builder.Services.RegisterNexusMediatorDependency();

            builder.Services.AddMudServices();
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
