using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackBlazor.Framework
{
    public class TimerSettings
    {
        public bool ClickSplitToTakeSplit { get; set; } = true;

        public bool IntervalMode { get; set; } = false;

        public bool DisplayTrending { get; set; } = true;

        public Decimal TrendingSplitDistance { get; set; } = 400;
        public Decimal TrendingTotalDistance { get; set; } = 1600;

        public TimeSpan GetTrending(int splitNum, TimeSpan soFar, TimeSpan mostRecentSplit) 
        {
            if(splitNum == 0)
                return TimeSpan.Zero;
            var left = TrendingTotalDistance - (splitNum * TrendingSplitDistance);
            if (left <= 0)
                return soFar;

            var leftFraction = left / TrendingSplitDistance;
            var trending = soFar + TimeSpan.FromTicks(Convert.ToInt64(mostRecentSplit.Ticks * leftFraction));
            return trending;
        }
    }
}
