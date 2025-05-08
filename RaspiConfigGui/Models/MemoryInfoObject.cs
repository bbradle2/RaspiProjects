using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class MemoryInfoObject : BaseInfoObject
    {
        public string? MemoryTotal { get; set; }
        public string? MemoryFree { get; set; }
        public string? MemoryAvailable { get; set; }
        public string? Cached { get; set; }
        public string? SwapCached { get; set; }
        public string? SwapFree { get; set; }
    }
}
