using System;
using System.Diagnostics;

namespace KeyboardPress_Analyzer
{
    public class CustomStopWatch : Stopwatch
    {
        public TimeSpan? StartOffset { get; set; }

        public CustomStopWatch(TimeSpan? startOffset)
        {
            StartOffset = startOffset;
        }

        public new long ElapsedMilliseconds
        {
            get
            {
                if (StartOffset == null)
                    return base.ElapsedMilliseconds;
                else
                    return base.ElapsedMilliseconds + (long)((TimeSpan)StartOffset).TotalMilliseconds;
            }
        }

        public new long ElapsedTicks
        {
            get
            {
                if (StartOffset == null)
                    return base.ElapsedTicks;
                else
                    return base.ElapsedTicks + ((TimeSpan)StartOffset).Ticks;
            }
        }

        public new TimeSpan Elapsed
        {
            get
            {
                if (StartOffset == null)
                    return base.Elapsed;
                else
                    return base.Elapsed + (TimeSpan)StartOffset;
            }
        }

    }
    
}
