using NexusExplorer.Mediator.Abstractions;
using NexusExplorer.Mediator.Implementations.Requests;
using NexusExplorer.Mediator.Implementations.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusExplorer.Mediator.Implementations.Handlers
{
    public class NexusExplorerServiceBusConnectionRequestHandler : INexusExplorerRequestHandler<INexusExplorerRequest, INexusExplorerResponse>
    {
        public bool CanHandle(INexusExplorerRequest request)
        {
            if (request is NexusExplorerServiceBusConnectionRequest response)
            {
                return true;
            }

            return false;
        }

        public Task<INexusExplorerResponse> Handle(INexusExplorerRequest request)
        {
            if (request is NexusExplorerServiceBusConnectionRequest connectionRequest)
            {
                return Task.FromResult(new NexusExplorerServiceBusConnectionResponse() as INexusExplorerResponse);
            }

            return Task.FromResult(new NexusExplorerServiceBusConnectionResponse() as INexusExplorerResponse);
        }
    }
}
