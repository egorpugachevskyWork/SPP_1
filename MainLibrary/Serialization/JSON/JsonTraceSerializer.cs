using MainLibrary.Tracer.JSON;
using System.Text.Json;

namespace MainLibrary.Serialization.JSON
{
    public class JsonTraceSerializer : ITraceSerializer
    {
        string ITraceSerializer.Serialize(MainLibrary.Tracer.TraceResult traceResult)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var attrTraceResult = new TraceResult(traceResult);
            string jsonString = JsonSerializer.Serialize<TraceResult>(attrTraceResult, options);
            return jsonString;
        }
    }
}
