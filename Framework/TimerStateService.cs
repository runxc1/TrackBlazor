namespace TrackBlazor.Framework
{
    public class TimerStateService
    {
        public List<PausableTimer> Timers { get; set; } = new List<PausableTimer>
        {
            new PausableTimer("Runner-1"),
            new PausableTimer("Runner-2"),
            new PausableTimer("Runner-3"),
            new PausableTimer("Runner-4")
        };
        public TimerSettings Settings { get; set; } = new TimerSettings();
        public bool AllStarted { get; set; } = false;
        public int CurrentCount { get; set; } = 6;
        public bool IsInitialized { get; set; } = false;
    }
}
