using System;
using System.Collections.Generic;
using System.Linq;

namespace Components.DatesAndTimes
{
    public class January : Month<January>
    {
        public January(int Year) : base(1, Year)
        { }

        public override February NextMonth()
        {
            return new February(Year);
        }

        public override December PreviousMonth()
        {
            var previousYear = Year - 1;

            return new December(previousYear);
        }
    }
    public class February : Month<February>
    {
        public February(int Year) : base(2, Year)
        { }

        public override March NextMonth()
        {
            return new March(Year);
        }

        public override January PreviousMonth()
        {
            return new January(Year);
        }
    }
    public class March : Month<March>
    {
        public March(int Year) : base(3, Year)
        { }

        public override April NextMonth()
        {
            return new April(Year);
        }

        public override February PreviousMonth()
        {
            return new February(Year);
        }
    }
    public class April : Month<April>
    {
        public April(int Year) : base(4, Year)
        { }

        public override May NextMonth()
        {
            return new May(Year);
        }

        public override March PreviousMonth()
        {
            return new March(Year);
        }
    }

    public class May : Month<May>
    {
        public May(int Year) : base(5, Year)
        { }

        public override June NextMonth()
        {
            return new June(Year);
        }

        public override April PreviousMonth()
        {
            return new April(Year);
        }
    }
    public class June : Month<June>
    {
        public June(int Year) : base(6, Year)
        { }

        public override July NextMonth()
        {
            return new July(Year);
        }

        public override May PreviousMonth()
        {
            return new May(Year);
        }
    }
    public class July : Month<July>
    {
        public July(int Year) : base(7, Year)
        { }

        public override August NextMonth()
        {
            return new August(Year);
        }

        public override June PreviousMonth()
        {
            return new June(Year);
        }
    }
    public class August : Month<August>
    {
        public August(int Year) : base(8, Year)
        { }

        public override September NextMonth()
        {
            return new September(Year);
        }

        public override July PreviousMonth()
        {
            return new July(Year);
        }
    }
    public class September : Month<September>
    {
        public September(int Year) : base(9, Year)
        { }

        public override October NextMonth()
        {
            return new October(Year);
        }

        public override August PreviousMonth()
        {
            return new August(Year);
        }
    }
    public class October : Month<October>
    {
        public October(int Year) : base(10, Year)
        { }

        public override November NextMonth()
        {
            return new November(Year);
        }

        public override September PreviousMonth()
        {
            return new September(Year);
        }
    }
    public class November : Month<November>
    {
        public November(int Year) : base(11, Year)
        { }

        public override December NextMonth()
        {
            return new December(Year);
        }

        public override October PreviousMonth()
        {
            return new October(Year);
        }
    }
    public class December : Month<December>
    {
        public December(int Year) : base(12, Year)
        { }

        public override January NextMonth()
        {
            return new January(Year + 1);
        }

        public override November PreviousMonth()
        {
            return new November(Year);
        }
    }

    public static class Months
    {
        public static IEnumerable<MonthBase> MonthList(int Year)
        {
            return new List<MonthBase>() 
            {
                new January(Year),
                new February(Year),
                new March(Year),
                new April(Year),
                new May(Year),
                new June(Year),
                new July(Year),
                new August(Year),
                new September(Year),
                new October(Year),
                new November(Year),
                new December(Year)
            };   
        }

        public static MonthBase ThisMonth(this DateTime d)
            => MonthList(d.Year).FirstOrDefault(a => a.Number.Equals(d.Month));
    }
}