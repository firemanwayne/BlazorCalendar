using System;

namespace Components.DatesAndTimes
{
    public class TimeSegment
    {
        public TimeSegment(DateTime Start, DateTime Stop)
        {
            if (Stop < Start)
                throw new ArgumentException("Stop Time cannot be greater than Start Time");

            if (Stop == Start)
                throw new ArgumentException("Start Date/Time cannot be the same as Stop Date/Time");

            this.Start = Start;
            this.Stop = Stop;

            Duration = Stop - Start;
        }

        public TimeSegment(DateTime Start, DateTime Stop, int StartTimeId, int StopTimeId)
        {
            this.StartTimeId = StartTimeId;
            this.StopTimeId = StopTimeId;

            StartTimeInterval = DailyTimeIntervals.GetDailyTimeIntervalFromId(StartTimeId);
            StopTimeInterval = DailyTimeIntervals.GetDailyTimeIntervalFromId(StopTimeId);

            this.Start = Start.Add(StartTimeInterval.TotalTimeSpan);
            this.Stop = Stop.Add(StopTimeInterval.TotalTimeSpan);

            if (this.Stop < this.Start)
                throw new ArgumentException("Stop Time cannot be greater than Start Time");

            if (this.Stop == this.Start)
                throw new ArgumentException("Start Date/Time cannot be the same as Stop Date/Time");

            Duration = this.Stop - this.Start;
        }

        public int StartTimeId { get; }
        public int StopTimeId { get; }
        public DateTime Start { get; }
        public DateTime Stop { get; }
        public TimeSpan Duration { get; }

        private DailyTimeIntervals StartTimeInterval { get; }
        private DailyTimeIntervals StopTimeInterval { get; }
    }
}
