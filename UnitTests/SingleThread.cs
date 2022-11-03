using MainLibrary.Tracer;
using NUnit.Framework;
using System.Collections.Generic;
using WorkingExample;

namespace UnitTests
{
    [TestFixture]
    public class SingleThread
    {
        private ITracer _tracer;
        private TraceResult _result;
        private static long ACCURACY = 30;

        public SingleThread()
        {
            _tracer = new Tracer();
            var foo = new Foo(_tracer);
            foo.MyMethod();
            _result = _tracer.GetTraceResult();
        }

        [Test]
        public void TraceResultCheckGeneralTime()
        {
            var ExecutionTime = _result.Threads[0].ElapsedTime;
            Assert.IsTrue(System.Math.Abs(ExecutionTime - 600) <= ACCURACY, $"Wrong time {ExecutionTime}");
        }

        [Test]
        public void TraceResultCompareNestedTime()
        {
            var ExecutionTime = _result.Threads[0].ElapsedTime;
            var nestedTimes = new List<long>();
            foreach(var thread in _result.Threads)
            {
                foreach(var meth in thread.Methods)
                {
                    nestedTimes.Add(meth.ElapsedTime);
                }
            }
            var isTrue = true;
            var errorString = "";
            for(int i = 0; i < nestedTimes.Count; ++i)
            {
                if (nestedTimes[i] > ExecutionTime)
                {
                    errorString = $"Wrong time of method {i} - {nestedTimes[i]} > {ExecutionTime} - ThreadTime";
                    isTrue = false;
                    break;
                }
            }
            
            Assert.IsTrue(isTrue, $"Wrong time {ExecutionTime}");
        }

        [Test]
        public void TraceResultCheckInnerMethodTime()
        {
            var ExecutionTime = _result.Threads[0].Methods[0].NestedMethods[0].ElapsedTime;
            Assert.IsTrue(System.Math.Abs(ExecutionTime - 400) <= ACCURACY, $"Wrong time {ExecutionTime}");
        }

        [Test]
        public void TraceResultCheckAmountOfNestedNemthodMyMethod()
        {
            var countNestedMethods = _result.Threads[0].Methods[0].NestedMethods.Count;
            Assert.IsTrue(countNestedMethods == 1, $"Wrong amount of nested methods {countNestedMethods}");
        }
    }
}