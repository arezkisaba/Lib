namespace Lib.Core
{
    public class SystemProcessModel
    {
        public int Pid { get; private set; }

        public string Name { get; private set; }

        public SystemProcessModel(int pid, string name)
        {
            Pid = pid;
            Name = name;
        }
    }
}