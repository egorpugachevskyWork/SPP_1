using MainLibrary.Serialization.JSON;
using System.Text.Json.Serialization;

namespace MainLibrary.Tracer.JSON
{
    public class TraceResult
    {
        [JsonPropertyName("threads")]
        public List<ThreadInformation> Threads { get; } = new List<ThreadInformation>() { };

        public TraceResult() { }

        public TraceResult(MainLibrary.Tracer.TraceResult traceResult)
        {
            foreach (var thread in traceResult.Threads)
            {
                Threads.Add(new ThreadInformation(thread));
            }
        }
    }
}
