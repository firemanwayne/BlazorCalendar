using System;

namespace Components.DatesAndTimes
{
    public static class DateTimeExtensions
    {
        public static Quarter GetQuarter(this DateTime Date)
        {           
            return Date.Month switch
            {
                1 => new Quarter(1),
                2 => new Quarter(1),
                3 => new Quarter(1),
                4 => new Quarter(2),
                5 => new Quarter(2),
                6 => new Quarter(2),
                7 => new Quarter(3),
                8 => new Quarter(3),
                9 => new Quarter(3),
                10 => new Quarter(4),
                11 => new Quarter(4),
                12 => new Quarter(4),
                _ => throw new NotImplementedException(),
            };
        }

        public static DateTime ToCST(this DateTime Date)
        {
            var CST = "Central Standard Time";
            return TimeZoneInfo.ConvertTime(Date, TimeZoneInfo.FindSystemTimeZoneById(CST));
        }

        public static DateTime RoundToHour(this DateTime d)
        {
            if (d.Minute >= 1 || d.Minute <= 29)
                return new DateTime(d.Year, d.Month, d.Day, d.Hour, 0, 0);
            else
                return new DateTime(d.Year, d.Month, d.Day, d.Hour + 1, 0, 0);
        }

        public static DateTime RoundToHalfHour(this DateTime d)
        {
            if (d.Minute >= 1 || d.Minute <= 14)
                return new DateTime(d.Year, d.Month, d.Day, d.Hour, 0, 0);
            else
                return new DateTime(d.Year, d.Month, d.Day, d.Hour, 30, 0);
        }
    }
}
