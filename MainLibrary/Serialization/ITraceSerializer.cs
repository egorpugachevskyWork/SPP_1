using MainLibrary.Tracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.Serialization
{
    public interface ITraceSerializer
    {
        string Serialize(TraceResult traceResult);   
    }
}
