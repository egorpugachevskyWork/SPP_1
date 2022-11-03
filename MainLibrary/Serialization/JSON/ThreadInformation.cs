using System.Text.Json.Serialization;

namespace MainLibrary.Serialization.JSON
{
    public class ThreadInformation
    {
        [JsonPropertyName("id")]

        public int Id { get; }

        [JsonPropertyName("time")]
        public long ElapsedTime { get; private set; }
        [JsonPropertyName("methods")]
        public List<MethodInformation> Methods { get; } = new List<MethodInformation>();

        public ThreadInformation() {}
        public ThreadInformation(MainLibrary.Information.ThreadInformation thread)
        {
            Id = thread.Id;
            ElapsedTime = thread.ElapsedTime;

            foreach(var method in thread.Methods)
            {
                Methods.Add(new MethodInformation(method));
            }
        }

    }
}
