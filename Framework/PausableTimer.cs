using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackBlazor.Framework
{
    public class PausableTimer
    {

        public PausableTimer(string name)
        {
            this.Name = name;
        }
        public bool editMode { get; set; } = false;
        public string Name { get; set; }
        public PausableStopWatch Stopwatch { get; set; } = new PausableStopWatch();
        public List<Split> Splits { get; set; } = new List<Split>();
        public bool StartedOnce { get; set; } = false;
        public void Start()
        {
            this.Stopwatch.Start();
            this.StartedOnce = true;
        }
        public void Stop()
        {
            Stopwatch.Stop();
        }
        public bool IsRunning { 
            get{
                return Stopwatch.IsRunning;
            }
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

}
