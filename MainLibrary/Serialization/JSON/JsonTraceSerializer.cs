using MainLibrary.Tracer.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MainLibrary.Serialization.JSON
{
    public class JsonTraceSerializer : ITraceSerializer
    {
        string ITraceSerializer.Serialize(MainLibrary.Tracer.TraceResult traceResult)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var attrTraceResult = new TraceResult(traceResult.Threads);
            string jsonString = JsonSerializer.Serialize<TraceResult>(attrTraceResult, options);
            return jsonString;
        }
    }
}
