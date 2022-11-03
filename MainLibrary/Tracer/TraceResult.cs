using MainLibrary.Information;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.Tracer
{
    public class TraceResult : ITracer
    {
        private ConcurrentDictionary<int, ThreadInformation> _threads = new ConcurrentDictionary<int, ThreadInformation>();

        private int _nesting = 0;
    }
}
