using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer.Functions
{
    public class RestReminder
    {
        // nice to have: saugoti/kaupti, kiek buvo pertraukų, kiek pertraukų ir t.t.

        private Stopwatch workStopwatch;
        private Stopwatch restStopwatch;

        public event EventHandler TimeToRest;

        private Task workTask;
        private bool runTask;

        private int workTimeSeconds;
        private int restTimeSeconds;
        private const int def_workTimeSeconds = 3600; //60min.
        private const int def_restTimeSeconds = 300; //5min.

        private object locker = new object();

        public RestReminder()
        {
            workStopwatch = new Stopwatch();
            restStopwatch = new Stopwatch();
            runTask = false;

            GetConfigValues();

            workTask = new Task(() => { workInProgress(); });
        }

        private void workInProgress()
        {
            while (runTask)
            {
                lock (locker)
                {
                    if (workStopwatch.Elapsed.TotalSeconds >= workTimeSeconds)
                        MakeAction(new EventArgs());

                    if (restStopwatch.Elapsed.TotalSeconds >= restTimeSeconds)
                        workStopwatch.Reset();
                }
                
                var waitTask = new Task(() => { Thread.Sleep(60000); });
                waitTask.Start();
                waitTask.Wait();
            }
        }

        public void Action()
        {
            lock (locker)
            {
                if (!workStopwatch.IsRunning)
                    workStopwatch.Start();
                restStopwatch.Restart();
            }
        }

        private void MakeAction(EventArgs e)
        {
            if (TimeToRest != null)
            {
                //workStopwatch.Reset();
                TimeToRest(this, e);
            }
        }

        public virtual void Start()
        {
            runTask = true;
            workStopwatch.Start();
            restStopwatch.Start();
            workTask.Start();
        }

        public virtual void Stop()
        {
            workStopwatch.Stop();
            restStopwatch.Stop();
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
        
        private void GetConfigValues()
        {
            try
            {
                var wt = ConfigurationManager.AppSettings["WorkTimeMin"].ToString();
                if(!String.IsNullOrWhiteSpace(wt))
                    workTimeSeconds = System.Convert.ToInt32(wt) * 60;
                else
                    workTimeSeconds = def_workTimeSeconds;
            }
            catch
            {
                workTimeSeconds = def_workTimeSeconds;
            }

            try
            {
                var rt = ConfigurationManager.AppSettings["RestTimeMin"].ToString();
                if(!String.IsNullOrWhiteSpace(rt))
                    restTimeSeconds = System.Convert.ToInt32(rt) * 60;
                else
                    restTimeSeconds = def_restTimeSeconds;
            }
            catch
            {
                restTimeSeconds = def_restTimeSeconds;
            }
        }
        

    }
}
