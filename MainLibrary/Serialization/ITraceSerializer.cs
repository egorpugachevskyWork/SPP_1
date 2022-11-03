using MainLibrary.Tracer;


namespace MainLibrary.Serialization
{
    public interface ITraceSerializer
    {
        string Serialize(TraceResult traceResult);   
    }
}
