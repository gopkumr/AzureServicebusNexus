using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusExplorer.Mediator.Abstractions
{
    public interface INexusExplorerRequestHandler<T, S> 
        where T : INexusExplorerRequest
        where S : INexusExplorerResponse
    {
        bool CanHandle(T request);

        Task<S> Handle(T request);
    }
}
