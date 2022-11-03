using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MainLibrary.Serialization.XML
{
    public class XMLSerializer : ITraceSerializer
    {
        string ITraceSerializer.Serialize(MainLibrary.Tracer.TraceResult traceResult)
        {
            using (var memStream = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(typeof(TraceResult));
                var streamWriter = XmlWriter.Create(memStream, new()
                {
                    Encoding = Encoding.UTF8,
                    Indent = true
                });
                xmlSerializer.Serialize(streamWriter, traceResult);
                return Encoding.UTF8.GetString(memStream.ToArray());
            }
        }
    }
}
