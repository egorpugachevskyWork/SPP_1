using MainLibrary.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.Tracer
{
    public class TraceResult
    {
        public IReadOnlyList<ThreadInformation> Threads { get; } = new List<ThreadInformation>() { };

        public TraceResult() { }
    
        public TraceResult(List<ThreadInformation> threads)
        {
            Threads = threads;
        }
    }
}
