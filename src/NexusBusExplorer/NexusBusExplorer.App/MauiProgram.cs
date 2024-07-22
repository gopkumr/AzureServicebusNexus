using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using NexusBusExplorer.Domain.Models;
using NexusBusExplorer.Domain.Services.Abstractions;
using NexusBusExplorer.AzureServiceBus.Implementations;

namespace NexusBusExplorer.App
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
