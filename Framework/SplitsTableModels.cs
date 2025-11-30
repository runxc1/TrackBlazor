namespace TrackBlazor.Framework
{
    public class SplitsTablePreset
    {
        public string Name { get; set; } = string.Empty;
        public int Distance { get; set; } = 1600;
        public List<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
        public List<int> SplitDistances { get; set; } = new List<int> { 200, 400, 800 };
    }

    public class TimeEntry
    {
        public string Name { get; set; } = string.Empty;
        public int TotalMinutes { get; set; }
        public int TotalSeconds { get; set; }

        public TimeSpan GetTotalTime()
        {
            return TimeSpan.FromMinutes(TotalMinutes) + TimeSpan.FromSeconds(TotalSeconds);
        }

        public string GetDisplayName()
        {
            return $"{Name}-{TotalMinutes}:{TotalSeconds:D2}";
        }
    }

    public class SplitCalculation
    {
        public string RunnerName { get; set; } = string.Empty;
        public Dictionary<int, TimeSpan> SplitTimes { get; set; } = new Dictionary<int, TimeSpan>();

        public static SplitCalculation Calculate(TimeEntry entry, int totalDistance, List<int> splitDistances)
        {
            var result = new SplitCalculation
            {
                RunnerName = entry.GetDisplayName()
            };

            var totalTime = entry.GetTotalTime();
            var pacePerMeter = totalTime.TotalSeconds / totalDistance;

            foreach (var splitDistance in splitDistances)
            {
                var splitSeconds = pacePerMeter * splitDistance;
                result.SplitTimes[splitDistance] = TimeSpan.FromSeconds(splitSeconds);
            }

            return result;
        }

        public string GetFormattedTime(int distance)
        {
            if (SplitTimes.TryGetValue(distance, out var time))
            {
                if (time.TotalMinutes >= 1)
                    return $"{(int)time.TotalMinutes}:{time.Seconds:D2}.{time.Milliseconds / 10:D2}";
                else
                    return $"{time.Seconds}.{time.Milliseconds / 10:D2}";
            }
            return "0.00";
        }
    }
}
