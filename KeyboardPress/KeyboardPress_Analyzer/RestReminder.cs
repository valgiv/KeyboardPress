using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer
{
    public class RestReminder
    {
        private Stopwatch workStopwatch;
        private Stopwatch restStopwatch;

        public event EventHandler TimeToRest;

        private Task workTask;
        private bool runTask;

        private const int workTimeMin = 45;
        private const int restTimeMin = 5;

        public RestReminder()
        {
            workStopwatch = new Stopwatch();
            restStopwatch = new Stopwatch();
            runTask = false;

            workTask = new Task(() => { workInProgress(); });
        }

        private void workInProgress()
        {
            while (runTask)
            {



                if (true)
                    MakeAction(new EventArgs());

                var waitTask = new Task(() => { Thread.Sleep(10000); });
                waitTask.Start();
                waitTask.Wait();
            }
        }

        public void Action()
        {
            if (!workStopwatch.IsRunning)
                workStopwatch.Start();
            restStopwatch.Restart();
        }

        private void MakeAction(EventArgs e)
        {
            if (TimeToRest != null)
            {
                workStopwatch.Reset();
                TimeToRest(this, e);
            }
        }

        public virtual void Start()
        {
            workStopwatch.Start();
            restStopwatch.Start();
            workTask.Start();
        }

        public virtual void Stop()
        {
            workStopwatch.Stop();
            runTask = false;

        }

        public virtual void Reset(bool startAfterReset)
        {
            workStopwatch = new Stopwatch();
            restStopwatch = new Stopwatch();
            runTask = false;

            workTask = new Task(() => { workInProgress(); });

            if (startAfterReset)
                Start();
        }

    }
}
