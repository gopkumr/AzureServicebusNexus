using NexusExplorer.Mediator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusExplorer.Mediator
{
    public static class NexusMediatorDependency
    {
        public static void RegisterNexusMediatorDependency(this IServiceCollection serviceCollection)
        {
            var commandType = typeof(INexusExplorerCommandHandler<INexusExplorerRequest>);
            var requestType = typeof(INexusExplorerRequestHandler<INexusExplorerRequest, INexusExplorerResponse>);

            var commandTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => commandType.IsAssignableFrom(p));

            var requestTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => requestType.IsAssignableFrom(p));

            foreach (var dependencyType in commandTypes)
                serviceCollection.AddScoped(commandType, dependencyType);

            foreach (var dependencyType in requestTypes)
                serviceCollection.AddScoped(requestType, dependencyType);

            serviceCollection.AddSingleton(typeof(NexusExplorerMediator));
        }
    }
}
