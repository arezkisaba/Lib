namespace Lib.Core
{
    public class SystemServiceModel
    {
        public string Name { get; set; }

        public bool IsStarted { get; set; }

        public bool IsStartedOnBoot { get; set; }

        public SystemServiceModel(string name, bool isStarted, bool isStartedOnBoot)
        {
            Name = name;
            IsStarted = isStarted;
            IsStartedOnBoot = isStartedOnBoot;
        }
    }
}