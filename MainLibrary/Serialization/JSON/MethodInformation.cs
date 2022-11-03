using System.Diagnostics;
using System.Text.Json.Serialization;

namespace MainLibrary.Serialization.JSON
{
    public class MethodInformation
    {

        [JsonPropertyName("name")]
        public string MethodName { get; } = "Default";

        [JsonPropertyName("class")]
        public string ClassName { get; } = "Default";

        [JsonPropertyName("time")]
        public long ElapsedTime { get; private set; }

        [JsonIgnore]
        public Stopwatch Clock { get; private set; } = new Stopwatch();

        [JsonPropertyName("methods")]
        public List<MethodInformation> NestedMethods { get; } = new List<MethodInformation>();

        [JsonIgnore]
        public bool IsHandled { get; private set; } = false;

        public MethodInformation() { }
        public MethodInformation(MainLibrary.Information.MethodInformation method)
        {
            MethodName = method.MethodName;
            ClassName = method.ClassName;
            ElapsedTime = method.ElapsedTime;

            foreach(var meth in method.NestedMethods)
            {
                NestedMethods.Add(new MethodInformation(meth));
            }
        }
    }
}
