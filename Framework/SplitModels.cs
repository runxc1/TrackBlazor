using System.Diagnostics;

namespace TrackBlazor.Framework
{
    public class Timer
    {
        public Timer(string name)
        {
            this.Name = name;
        }
        public bool editMode { get; set; } = false;
        public string Name { get; set; }
        public Stopwatch Stopwatch { get; set; } = new Stopwatch();
        public List<Split> Splits { get; set; } = new List<Split>();
        public bool StartedOnce { get; set; } = false;
        public void Start()
        {
            this.Stopwatch.Start();
            this.StartedOnce = true;
        }
        public void Stop()
        {
            if (Stopwatch.IsRunning)
                Stopwatch.Stop();
        }
        public void TakeSplit()
        {
            var ts = this.Stopwatch.Elapsed;
            var last = this.Splits.LastOrDefault();
            this.Splits.Add(new Split(ts, last?.Ellapsed));
        }
        public void Reset()
        {
            this.Stopwatch.Reset();
            this.Splits.Clear();
        }
        public TimeSpan ElapsedSinceLast
        {
            get
            {
                if (this.Splits.Any())
                {
                    return this.Stopwatch.Elapsed - this.Splits.Last().Ellapsed;
                }
                else
                {
                    return this.Stopwatch.Elapsed;
                }
            }
        }
    }
    public class Split
    {
        public TimeSpan Ellapsed { get; set; }
        public TimeSpan SplitTime { get; set; }

        public Split(TimeSpan ts, TimeSpan? previous)
        {
            this.Ellapsed = ts;
            if (previous.HasValue)
                this.SplitTime = ts - previous.Value;
            else
                this.SplitTime = ts;
        }
    }
    public class SplitResults
    {
        public DateTime SaveTime { get; set; }
        public List<SplitResult> Results { get; set; } = new List<SplitResult>();
    }
    public class SplitResult
    {
        public string? Name { get; set; }
        public int Number { get; set; }
        public TimeSpan Ellapsed { get; set; }
        public TimeSpan SplitTime { get; set; }
    }
}
