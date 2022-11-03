using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.Serialization
{
    public class FileTraceWriter : ITraceWriter
    {
        private string _path = "";

        public FileTraceWriter(string path)
        {
            _path = path;
        }

        void ITraceWriter.Write(string traceResult)
        {
            using (StreamWriter sw = new StreamWriter(_path, false))
            {
                sw.Write(traceResult);
            }
        }
    }
}
