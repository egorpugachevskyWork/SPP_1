using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
