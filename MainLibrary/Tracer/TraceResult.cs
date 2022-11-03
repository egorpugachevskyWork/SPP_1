using MainLibrary.Information;

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
