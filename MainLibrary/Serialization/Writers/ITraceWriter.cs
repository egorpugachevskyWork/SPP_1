using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.Serialization.Writers
{
    public interface ITraceWriter
    {
        void Write(string traceResult);
    }
}
