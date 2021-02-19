using System;

namespace Components.DatesAndTimes
{
    public abstract class TimeBlockBase
    {
        TimeBlockBase()
        {
            Start = new DateTime();
            Stop = new DateTime();
            Duration = new TimeSpan();
        }

        protected TimeBlockBase(TimeIncrements Increment, DateTime Start, DateTime Stop, int StartId, int StopId)
        {
            if (Stop < Start)
                throw new ArgumentException("Stop Time cannot be greater than Start Time");

            if (StartId.Equals(0) || StopId.Equals(0))
                throw new ArgumentException("Start Id and/or Stop Id cannot be 0");

            this.StartId = StartId;
            this.StopId = StopId;
            this.Start = Start;
            this.Stop = Stop;
            TimeIncrement = Increment;
            StartInterval = DailyTimeIntervals.GetDailyTimeIntervalFromId(StartId);
            StopInterval = DailyTimeIntervals.GetDailyTimeIntervalFromId(StopId);

            this.Start = Start.Add(StartInterval.TotalTimeSpan);
            this.Stop = Stop.Add(StopInterval.TotalTimeSpan);

            Duration = this.Stop - this.Start;
        }

        protected int NumberSegments { get; }
        protected int StartId { get; }
        protected DateTime Start { get; set; }
        protected int StopId { get; }
        protected DateTime Stop { get; }
        protected TimeSpan Duration { get; }
        protected TimeIncrements TimeIncrement { get; }

        DailyTimeIntervals StartInterval { get; set; }
        DailyTimeIntervals StopInterval { get; set; }
    }
}