using System.Xml.Schema;
using System.Xml.Serialization;

namespace MainLibrary.Serialization.XML
{
    public class MethodInformation
    {
        [XmlAttribute(AttributeName = "name", Form = XmlSchemaForm.Unqualified)]
        public string MethodName { get; set;  } = "Default";

        [XmlAttribute(AttributeName = "class", Form = XmlSchemaForm.Unqualified)]
        public string ClassName { get; set;  } = "Default";

        [XmlAttribute(AttributeName = "time", Form = XmlSchemaForm.Unqualified)]
        public long ElapsedTime { get; set; }

        [XmlElement(ElementName = "method")]
        public List<MethodInformation> NestedMethods { get; set; } = new List<MethodInformation>();

        public MethodInformation() { }
        public MethodInformation(MainLibrary.Information.MethodInformation method)
        {
            MethodName = method.MethodName;
            ClassName = method.ClassName;
            ElapsedTime = method.ElapsedTime;

            foreach (var meth in method.NestedMethods)
            {
                NestedMethods.Add(new MethodInformation(meth));
            }
        }
    }
}
