using MainLibrary.Information;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
namespace MainLibrary.Tracer
{
    public class Tracer : ITracer
    {
        private ConcurrentDictionary<int, ThreadInformation> _threads = new ConcurrentDictionary<int, ThreadInformation>();

        //I need to fix working with multiple threads(tracer is general for multiple threads, therefore i need separate variables
        //for separate theads)
        private ConcurrentDictionary<int, int> _threadsNesting = new ConcurrentDictionary<int, int>();


        private MethodInformation FindAndAddMethodThread(StackTrace stackTrace, List<MethodInformation> threadMethods, int currentThreadId)
        {
            var currentLayerMethods = threadMethods;
            var isMethodFound = false;
            int i = 1 + _threadsNesting[currentThreadId];
            MethodInformation foundMethod = null;
            //i > 0 'cause stackTrace was invoked in StartTrace or StopTrace
            //And our stackTrace start with that method, so we need to catch methods 'till entry point
            while (!isMethodFound && i > 0)
            {
                var wantedMethodName = stackTrace.GetFrame(i).GetMethod().Name;
                var wantedMethodClassName = stackTrace.GetFrame(i).GetMethod().DeclaringType.Name;
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
            _threadsNesting.TryAdd(currentThreadId, 0);
            var stackTrace = new StackTrace();
            var method = FindAndAddMethodThread(stackTrace, _threads[currentThreadId].Methods, currentThreadId);
            _threadsNesting[currentThreadId]++;
            method.StartTracing();
        }

        void ITracer.StopTrace()
        {
            int currentThreadId = Thread.CurrentThread.ManagedThreadId;
            if (_threads.TryGetValue(currentThreadId, out var stackTraceTemp))
            {
                var stackTrace = new StackTrace();
                _threadsNesting[currentThreadId]--;
                var method = FindAndAddMethodThread(stackTrace, _threads[currentThreadId].Methods, currentThreadId);
                method.StopTracing();
            }
            else
            {
                Console.WriteLine("First of all u need to star tracing method, then stop");
            }
        }

        TraceResult ITracer.GetTraceResult()
        {
            var threadsList = new List<ThreadInformation>();

            foreach(var thread in _threads.Values)
            {
                thread.EstimateElapsedTime();
                threadsList.Add(thread);
            }

            return new TraceResult(threadsList);
        }
    }
}
