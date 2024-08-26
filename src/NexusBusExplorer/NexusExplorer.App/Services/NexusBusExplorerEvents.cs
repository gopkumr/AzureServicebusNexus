using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusExplorer.App.Services
{
    internal class NexusExplorerEvents : INexusExplorerEvents
    {
        public GlobalEvent? OnServicebusConnected { get; set; }
    }
}
