using MainLibrary.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.Serialization.XML
{
    public class TraceResult
    {
        public List<ThreadInformation> Threads { get; } = new List<ThreadInformation>() { };

        public TraceResult() { }
    
        public TraceResult(List<ThreadInformation> threads)
        {
            Threads = threads;
        }
    }
}
