using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.Serialization
{
    public class ConsoleTraceWriter : ITraceWriter
    {
        void ITraceWriter.Write(string traceResult)
        {
            Console.WriteLine(traceResult);
        }
    }
}
