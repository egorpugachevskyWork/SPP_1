using MainLibrary.Serialization.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MainLibrary.Tracer.JSON
{
    public class TraceResult
    {
        [JsonPropertyName("threads")]
        public List<ThreadInformation> Threads { get; } = new List<ThreadInformation>() { };

        public TraceResult() { }
    
        public TraceResult(IReadOnlyList<MainLibrary.Information.ThreadInformation> threads)
        {
            foreach(var thread in threads)
            {
                Threads.Add(new ThreadInformation(thread));
            }
        }
    }
}
