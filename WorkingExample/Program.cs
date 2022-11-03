using MainLibrary.Tracer;

namespace WorkingExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            ITracer tracer = new Tracer();
            var foo = new Foo(tracer);

            
         //   foo.MyMethod();//one method works perfectly
         //   foo.MyMethod();//multiple methods work perfectly too
            var t1 = new Task(() => foo.MyMethod());
            var t2  = new Task(() => {
                foo.MyMethod();
                foo.MyMethod();
            });

            t1.Start();
            t2.Start();

            t1.Wait();
            t2.Wait();

            //Thread broke everthing
            var result = tracer.GetTraceResult();
            Console.WriteLine();
        }
    }
}