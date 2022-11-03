using MainLibrary.Tracer;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkingExample;

namespace UnitTests
{
    [TestFixture]
    public class MultipleThread
    {
        private ITracer _tracer;
        private TraceResult _result;
        private static long ACCURACY = 50;

        public MultipleThread()
        {
            _tracer = new Tracer();
            var foo = new Foo(_tracer);
            var t1 = new Task(() => foo.MyMethod());
            var t2 = new Task(() => {
                foo.MyMethod();
                foo.MyMethod();
            });

            t1.Start();
            t2.Start();

            t1.Wait();
            t2.Wait();

            _result = _tracer.GetTraceResult();
        }

        [Test]
        public void TraceResultCheckGeneralTime()
        {
            long ExecutionTime = 0;
            for (int i = 0; i < _result.Threads.Count; i++)
            {
                ExecutionTime += _result.Threads[i].ElapsedTime;
            } 

            
            Assert.IsTrue(System.Math.Abs(ExecutionTime - 600 * 3) <= ACCURACY * 2, $"Wrong time {ExecutionTime}");
        }

        [Test]
        public void TraceResultCompareNestedTimeThread1()
        {
            var ExecutionTime = _result.Threads[0].ElapsedTime;
            var nestedTimes = new List<long>();
            foreach (var thread in _result.Threads)
            {
                foreach (var meth in thread.Methods)
                {
                    nestedTimes.Add(meth.ElapsedTime);
                }
            }
            var isTrue = true;
            var errorString = "";
            for (int i = 0; i < nestedTimes.Count; ++i)
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
        public void TraceResultCheckInnerMethodTimeThread1()
        {
            var ExecutionTime = _result.Threads[0].Methods[0].NestedMethods[0].ElapsedTime;
            Assert.IsTrue(System.Math.Abs(ExecutionTime - 400) <= ACCURACY, $"Wrong time {ExecutionTime}");
        }

        [Test]
        public void TraceResultCheckAmountOfNestedNemthodMyMethodThread1()
        {
            var countNestedMethods = _result.Threads[0].Methods[0].NestedMethods.Count;
            Assert.IsTrue(countNestedMethods == 1, $"Wrong amount of nested MyMethod(Thread1) methods {countNestedMethods}");
        }

        [Test]
        public void TraceResultCheckAmountOfNestedThreadMethods()
        {
            long count = 0;
            for (int i = 0; i < _result.Threads.Count; i++)
            {
                count += _result.Threads[i].Methods.Count;
            }
            Assert.IsTrue(count == 3, $"Wrong amount of nested thread methods {count}");
        }
    }
}