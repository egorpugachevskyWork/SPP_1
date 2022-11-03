using MainLibrary.Tracer;

namespace WorkingExample
{
    public class Boo
    {
        private ITracer _tracer;

        public Boo(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();

            SuperInnerMethod();

            _tracer.StopTrace();
        }

        public void SuperInnerMethod()
        {
            _tracer.StartTrace();

            Thread.Sleep(400);

            _tracer.StopTrace();
        }
    }
}
