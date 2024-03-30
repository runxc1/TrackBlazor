﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackBlazor.Framework
{
    public class PausableStopWatch
    {
        private long _totalTicks = 0;
        private long _elapsedTicks = 0;
        private long _ticksMarker = 0;
        public void Start()
        {
            _ticksMarker = Environment.TickCount;
        }
        public void Stop()
        {
            var now = Environment.TickCount;
            if(_ticksMarker > 0)
            {
                _totalTicks += now - _ticksMarker;
            }
            _ticksMarker = 0;
        }
        public bool IsRunning
        {
            get
            {
                return _ticksMarker > 0;
            }
        }
        public void Reset()
        {
            _ticksMarker = 0;
            _totalTicks = 0;
            _elapsedTicks = 0;
        }

        public TimeSpan Elapsed
        {
            get
            {
                var now = Environment.TickCount;
                var elapsed = _totalTicks;
                if (_ticksMarker > 0)
                    elapsed += now - _ticksMarker;
                return TimeSpan.FromMilliseconds(elapsed);
            }
        }
    }
}