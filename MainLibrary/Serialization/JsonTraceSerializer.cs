using MainLibrary.Tracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MainLibrary.Serialization
{
    public class JsonTraceSerializer : ITraceSerializer
    {
        string ITraceSerializer.Serialize(TraceResult traceResult)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize<TraceResult>(traceResult, options);
            return jsonString;
        }
    }
}
