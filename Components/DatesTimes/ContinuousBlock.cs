using System;

namespace Components.DatesAndTimes
{
    public class ContinuousBlock : TimeBlock
    {
        public TimeSegment Segment { get; }

        public ContinuousBlock(int StartId, int StopId, DateTime Start, DateTime Stop) : base(TimeIncrements.None, Start, Stop, StartId, StopId)
        {
            if (NumberSegments > 1)
                throw new InvalidOperationException("Number segments cannot be greater than 1 for Continuous Block");

            Segment = new TimeSegment(Start, Stop, StartId, StopId);
        }
    }
}
