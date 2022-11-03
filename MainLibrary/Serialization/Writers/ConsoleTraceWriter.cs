namespace MainLibrary.Serialization.Writers
{
    public class ConsoleTraceWriter : ITraceWriter
    {
        void ITraceWriter.Write(string traceResult)
        {
            Console.WriteLine(traceResult);
        }
    }
}
