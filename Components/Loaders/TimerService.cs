using System;
using System.Timers;

namespace Components.Loaders
{
    public class TimerService
    {
        private Timer timer;

        public void SetTimer(double interval)
        {
            timer = new Timer(interval);
            timer.Elapsed += NotifyTimerElapsed;
            timer.Enabled = true;
        }

        public event Action OnElapsed;

        private void NotifyTimerElapsed(object source, ElapsedEventArgs e)
        {
            OnElapsed?.Invoke();
            timer.Dispose();
        }
    }
}
