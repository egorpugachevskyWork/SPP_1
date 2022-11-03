using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MainLibrary.Serialization.XML
{
    public class ThreadInformation
    {
        [XmlAttribute(AttributeName = "id", Form = XmlSchemaForm.Unqualified)]
        public int Id { get; set;  }

        [XmlAttribute(AttributeName = "time", Form = XmlSchemaForm.Unqualified)]
        public long ElapsedTime { get; set; }

        [XmlElement(ElementName = "method")]
        public List<MethodInformation> Methods { get; set; } = new List<MethodInformation>();

        public ThreadInformation() {}
        public ThreadInformation(MainLibrary.Information.ThreadInformation thread)
        {
            Id = thread.Id;
            ElapsedTime = thread.ElapsedTime;

            foreach (var method in thread.Methods)
            {
                Methods.Add(new MethodInformation(method));
            }
        }
    }
}
