using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusExplorer.Domain.Models
{
    public class NexusAuthenticationOptions
    {
        public string? ConnectionString { get; set; }
        public string? TenantId { get; set; }
    }
}
