using System;
using System.Collections.Generic;

namespace Components.DatesAndTimes
{
    public class SegmentedBlock : TimeBlock
    {
        private const int FifteenMinutes = 15;
        private const int HalfHour = 30;
        private const int HoursInDay = 24;
        private const int MinutesInHour = 60;
        private readonly static int MinutesInDay = MinutesInDay * HoursInDay;

        public SegmentedBlock(TimeIncrements Increment, int StartId, int StopId, DateTime Start, DateTime Stop) : base(Increment, Start, Stop, StartId, StopId)
        {
            CreateSegments();
        }

        private void CreateSegments()
        {
            switch (TimeIncrement)
            {
                case TimeIncrements.Daily:
                    CreateDailySegments();
                    break;
                case TimeIncrements.Hourly:
                    CreateHourlySegments();
                    break;
                case TimeIncrements.HalfHour:
                    CreateHalfHourSegments();
                    break;
                case TimeIncrements.Fifthteen:
                    CreateQuarterHourSegments();
                    break;
                case TimeIncrements.None:
                    CreateDefaultSegments();
                    break;
                default:
                    CreateDefaultSegments();
                    break;
            }
        }
        private void CreateDailySegments()
        {
            int DayCounter = 0;
            int TotalDays = Duration.Days;

            DateTime Start = this.Start;
            DateTime End = this.Start;

            while (DayCounter < TotalDays)
            {
                if (DayCounter > 0)
                    Start = Start.AddHours(HoursInDay);

                End = End.AddHours(HoursInDay);

                StartIntervalId = DailyTimeIntervals.GetTimeIntervalFromHourMinute(Start.Hour, Start.Minute).Id;
                EndIntervalId = DailyTimeIntervals.GetTimeIntervalFromHourMinute(End.Hour, End.Minute).Id;

                Segments.Add(new TimeSegment(Start, End, StartIntervalId, EndIntervalId));
                DayCounter++;
            }
        }
        private void CreateHourlySegments()
        {
            int HourCounter = 0;
            int TotalHours = Duration.Hours;

            DateTime Start = this.Start;
            DateTime End = this.Start;

            while (HourCounter < TotalHours)
            {
                if (HourCounter > 0)
                    Start = Start.AddHours(1);
                End = End.AddHours(1);

                StartIntervalId = DailyTimeIntervals.GetTimeIntervalFromHourMinute(Start.Hour, Start.Minute).Id;
                EndIntervalId = DailyTimeIntervals.GetTimeIntervalFromHourMinute(End.Hour, End.Minute).Id;

                Segments.Add(new TimeSegment(Start, End, StartIntervalId, EndIntervalId));
                HourCounter++;
            }
        }
        private void CreateHalfHourSegments()
        {
            int HourCounter = 0;
            int TotalHalfHours = Duration.Hours * 2;

            DateTime Start = this.Start;
            DateTime End = this.Start;

            while (HourCounter < TotalHalfHours)
            {
                if (HourCounter > 0)
                    Start = Start.AddMinutes(HalfHour);

                End = End.AddMinutes(HalfHour);

                StartIntervalId = DailyTimeIntervals.GetTimeIntervalFromHourMinute(Start.Hour, Start.Minute).Id;
                EndIntervalId = DailyTimeIntervals.GetTimeIntervalFromHourMinute(End.Hour, End.Minute).Id;

                Segments.Add(new TimeSegment(Start, End, StartIntervalId, EndIntervalId));
                HourCounter++;
            }
        }
        private void CreateQuarterHourSegments()
        {
            int QuarterCounter = 0;
            int TotalQuarterHours = Duration.Hours * 4;

            DateTime Start = this.Start;
            DateTime End = this.Start;

            while (QuarterCounter < TotalQuarterHours)
            {
                if (QuarterCounter > 0)
                    Start = Start.AddMinutes(FifteenMinutes);

                End = End.AddMinutes(FifteenMinutes);

                StartIntervalId = DailyTimeIntervals.GetTimeIntervalFromHourMinute(Start.Hour, Start.Minute).Id;
                EndIntervalId = DailyTimeIntervals.GetTimeIntervalFromHourMinute(End.Hour, End.Minute).Id;

                Segments.Add(new TimeSegment(Start, End, StartIntervalId, EndIntervalId));
                QuarterCounter++;
            }
        }
        private void CreateDefaultSegments()
        {
            Segments.Add(new TimeSegment(Start, Stop));
        }

        private int StartIntervalId { get; set; }
        private int EndIntervalId { get; set; }

        public IList<TimeSegment> Segments { get; } = new List<TimeSegment>();
    }
}
