using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MainLibrary.Serialization.XML
{
    public class XMLTraceSerializer : ITraceSerializer
    {
        string ITraceSerializer.Serialize(MainLibrary.Tracer.TraceResult traceResult)
        {
            var attrTraceResult = new TraceResult(traceResult);
            using (var memStream = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(typeof(TraceResult));
                var streamWriter = XmlWriter.Create(memStream, new()
                {
                    Encoding = Encoding.UTF8,
                    Indent = true
                });
                xmlSerializer.Serialize(streamWriter, attrTraceResult);
                return Encoding.UTF8.GetString(memStream.ToArray());
            }
        }
    }
}
