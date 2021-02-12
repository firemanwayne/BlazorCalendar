using Components.DatesAndTimes;
using System;
using System.Collections.Generic;

namespace Components.DatesTimes.Concrete
{
    public class Year
    {
        public int Number { get; }

        public Year(int Number)
        {
            this.Number = Number;
        }
        public Year()
        {
            Number = DateTime.Today.Year;
        }

        public IEnumerable<MonthBase> Months { get; set; } = new List<MonthBase>();

        public static implicit operator int(Year y) => y.Number;
    }
}
