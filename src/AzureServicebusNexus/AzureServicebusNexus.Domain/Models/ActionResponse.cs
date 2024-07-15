using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureServicebusNexus.Domain.Models
{
    public class ActionResponse<T>
    {
        public T Content { get; set; } = default!;

        public bool Success { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;
    }
}
