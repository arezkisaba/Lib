namespace Lib.Core
{
    public static class TimeHelper
    {
        public static int FromMilliSeconds(int milliseconds)
        {
            return 1 * milliseconds;
        }

        public static int FromSecondsToMilliseconds(int seconds)
        {
            return 1000 * seconds;
        }

        public static int FromMinutesToMilliseconds(int minutes)
        {
            return 1000 * 60 * minutes;
        }

        public static int FromHoursToMilliseconds(int hours)
        {
            return 1000 * 60 * 60 * hours;
        }
    }
}
