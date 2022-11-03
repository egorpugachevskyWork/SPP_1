using MainLibrary.Information;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.Tracer
{
    public class TraceResult : ITracer
    {
        private ConcurrentDictionary<int, ThreadInformation> _threads = new ConcurrentDictionary<int, ThreadInformation>();

        private int _nesting = 0;

        private MethodInformation FindAndAddMethodThread(StackTrace stackTrace, List<MethodInformation> threadMethods)
        {
            var currentLayerMethods = threadMethods;
            var isMethodFound = false;
            int i = 1 + _nesting;
            MethodInformation foundMethod = null;
            //i > 0 'cause stackTrace was invoked in StartTrace or StopTrace
            //And our stackTrace start with that method, so we need to catch methods 'till entry point
            while (!isMethodFound && i > 0)
            {
                var wantedMethodName = stackTrace.GetFrame(i).GetMethod().Name;
                var wantedMethodClassName = stackTrace.GetFrame(i).GetMethod().DeclaringType;
                foundMethod = currentLayerMethods.Find(method => method.MethodName.Equals(wantedMethodName)
                                                       && method.ClassName.Equals(wantedMethodClassName)
                                                       && !method.IsHandled);
                if (foundMethod != null)
                {
                    currentLayerMethods = foundMethod.NestedMethods;
                    i--;
                }
                else
                {
                    foundMethod = new MethodInformation(wantedMethodName, wantedMethodClassName);
                    currentLayerMethods.Add(foundMethod);
                    isMethodFound = true;
                }
            }

            return foundMethod; 
        }

        void ITracer.StartTrace()
        {
            int currentThreadId = Thread.CurrentThread.ManagedThreadId;
            _threads.TryAdd(currentThreadId, new ThreadInformation(currentThreadId));
            var stackTrace = new StackTrace();
            var method = FindAndAddMethodThread(stackTrace, _threads[currentThreadId].Methods);
            Interlocked.Increment(ref _nesting);
            method.StartTracing();
        }
    }
}
