using MainLibrary.Information;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MainLibrary.Serialization.XML
{
    [XmlRoot(ElementName = "root")]
    public class TraceResult
    {
        [XmlElement(ElementName = "threads")]
        public List<ThreadInformation> Threads { get; set; } = new List<ThreadInformation>() { };

        public TraceResult() { }
    
        public TraceResult(MainLibrary.Tracer.TraceResult traceResult)
        {
            foreach(var thread in traceResult.Threads)
            {
                Threads.Add(new ThreadInformation(thread));
            }
        }
    }
}
