using MainLibrary.Serialization;
using MainLibrary.Serialization.JSON;
using MainLibrary.Serialization.Writers;
using MainLibrary.Tracer;

namespace WorkingExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            ITracer tracer = new Tracer();
            var foo = new Foo(tracer);

            var t1 = new Task(() => foo.MyMethod());
            var t2  = new Task(() => {
                foo.MyMethod();
                foo.MyMethod();
            });

            t1.Start();
            t2.Start();

            t1.Wait();
            t2.Wait();

            var result = tracer.GetTraceResult();
            ITraceSerializer jsonSerializaer = new JsonTraceSerializer();
            var jsonString = jsonSerializaer.Serialize(result); 

            ITraceWriter consoleWriter = new ConsoleTraceWriter();
            ITraceWriter fileWriter = new FileTraceWriter("D:\\forlab1.txt");

            consoleWriter.Write(jsonString);
            fileWriter.Write(jsonString);
        }
    }
}