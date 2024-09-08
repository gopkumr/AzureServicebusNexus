using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusExplorer.Mediator.Abstractions
{
    public interface INexusExplorerCommandHandler<T> 
        where T : INexusExplorerRequest
    {
        bool CanHandle(T request);

        Task Handle(T request);
    }
}
