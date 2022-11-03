using MainLibrary.Tracer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingExample
{
    public class Foo
    {
        private Boo _boo;
        private ITracer _tracer;

        public Foo(ITracer tracer)
        {
            _tracer = tracer;
            _boo = new Boo(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();

            _boo.InnerMethod();
            Thread.Sleep(200);

            _tracer.StopTrace();
        }
    }
}
