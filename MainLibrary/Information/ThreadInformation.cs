namespace MainLibrary.Information
{
    public class ThreadInformation
    {
        public int Id { get; }

        public long ElapsedTime { get; private set; }

        public List<MethodInformation> Methods { get; } = new List<MethodInformation>();

        public ThreadInformation() {}
        public ThreadInformation(int id)
        {
            Id = id;
        }

        public void EstimateElapsedTime()
        {
            foreach (var method in Methods)
            {
                ElapsedTime += method.ElapsedTime;
            }
        }
    }
}
