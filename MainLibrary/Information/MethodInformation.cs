using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MainLibrary.Information
{
    public class MethodInformation
    {
        public string MethodName { get; } = "Default";

        public string ClassName { get; } = "Default";

        public long ElapsedTime { get; private set; }

        public Stopwatch Clock { get; private set; } = new Stopwatch();

        public List<MethodInformation> NestedMethods { get; } = new List<MethodInformation>();

        public bool IsHandled { get; private set; } = false;

        public MethodInformation() { }
        public MethodInformation(string methodName, string className)
        {
            MethodName = methodName;
            ClassName = className;
        }

        public void StartTracing()
        {
            Clock.Reset();
            Clock.Start();
        }

        public void StopTracing()
        {
            Clock.Stop();
            IsHandled = true;
            ElapsedTime += Clock.ElapsedMilliseconds;
        }
    }
}
