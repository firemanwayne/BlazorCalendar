using System.Collections.Generic;

namespace Components.DatesAndTimes
{
    public class LifeCycle
    {
        private LifeCycle() { }
        private LifeCycle(int id)
        {
            this.Id = id;
        }

        private int Id { get; }
        public string UnitMeasure { get; }

        public IEnumerable<KeyValuePair<int, string>> Types { get; }

        readonly IList<LifeCycleType> types = new List<LifeCycleType>
        {
            new LifeCycleType(0, "Years"),
            new LifeCycleType(1, "Months"),
            new LifeCycleType(2, "Weeks"),
            new LifeCycleType(3, "Days")
        };
    }
}
