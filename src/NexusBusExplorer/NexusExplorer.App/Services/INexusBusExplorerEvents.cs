
using NexusExplorer.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusExplorer.App.Services
{
    delegate void GlobalEvent(NexusExplorerEventArgs args);

    internal interface INexusExplorerEvents
    {
        GlobalEvent? OnServicebusConnected { get; set; } 


    }
}
