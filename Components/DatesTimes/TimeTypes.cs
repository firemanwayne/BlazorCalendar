using System;
using System.Collections.Generic;

namespace Components.DatesAndTimes
{
    public class TimeTypes
    {
        private TimeTypes() { }

        private TimeTypes(string Start, string Stop, int StartId, int StopId)
        {
            if (DateTime.TryParse(Start, out DateTime StartResult) && DateTime.TryParse(Stop, out DateTime StopResult))
            {
                Id = nameof(TimeTypeEnum.Continuous);
                Name = nameof(TimeTypeEnum.Continuous);
                Block = new ContinuousBlock(StartId, StopId, StartResult, StopResult);
            }
        }
        private TimeTypes(DateTime Start, DateTime Stop, int StartId, int StopId)
        {
            Id = nameof(TimeTypeEnum.Continuous);
            Name = nameof(TimeTypeEnum.Continuous);
            Block = new ContinuousBlock(StartId, StopId, Start, Stop);
        }
        private TimeTypes(TimeIncrements Increment, string Start, string Stop, int StartId, int StopId)
        {
            if (DateTime.TryParse(Start, out DateTime StartResult) && DateTime.TryParse(Stop, out DateTime StopResult))
            {
                Id = nameof(TimeTypeEnum.Segmented);
                Name = nameof(TimeTypeEnum.Segmented);
                Block = new SegmentedBlock(Increment, StartId, StopId, StartResult, StopResult);
            }
        }
        private TimeTypes(TimeIncrements Increment, DateTime Start, DateTime Stop, int StartId, int StopId)
        {
            Id = nameof(TimeTypeEnum.Segmented);
            Name = nameof(TimeTypeEnum.Segmented);
            Block = new SegmentedBlock(Increment, StartId, StopId, Start, Stop);
        }

        public static TimeTypes Create(string Start, string Stop, int StartId, int StopId)
        {
            TimeTypes Type = new(Start, Stop, StartId, StopId) { NumberBlocks = 1 };
            return Type;
        }
        public static TimeTypes Create(DateTime Start, DateTime Stop, int StartId, int StopId)
        {
            TimeTypes Type = new(Start, Stop, StartId, StopId) { NumberBlocks = 1 };
            return Type;
        }
        public static TimeTypes Create(TimeIncrements Increment, string Start, string Stop, int StartId, int StopId)
        {
            return new TimeTypes(Increment, Start, Stop, StartId, StopId);
        }
        public static TimeTypes Create(TimeIncrements Increment, DateTime Start, DateTime Stop, int StartId, int StopId)
        {
            return new TimeTypes(Increment, Start, Stop, StartId, StopId);
        }

        public TimeBlockBase GetTimeBlock() => Block;

        public static IList<TimeTypes> Types { get; } = new List<TimeTypes>
        {
            new TimeTypes(){Id = "Segmented", Name = "Segmented" },
            new TimeTypes(){Id = "Continuous", Name = "Continuous" }
        };

        public string Id { get; init; }
        public string Name { get; init; }
        public int NumberBlocks { get; init; }

        private TimeBlockBase Block { get; set; }
        private enum TimeTypeEnum { Continuous, Segmented }
    }

    public enum TimeIncrements { Fifthteen = 1, HalfHour = 2, Hourly = 3, Daily = 4, None = 0 }
}
