using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusExplorer.Mediator.Exceptions
{
    public class NexusExplorerMediatorException: Exception
    {
        public NexusExplorerMediatorException(string message) : base(message)
        {

        }
    }
}
