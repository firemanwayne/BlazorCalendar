using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Components.DatesAndTimes
{
    public class Week
    {        
        readonly DateTime Today;
        readonly static CultureInfo Culture = new("en-US");
        readonly static Calendar Calendar = Culture.Calendar;
        readonly static CalendarWeekRule WeekRule = Culture.DateTimeFormat.CalendarWeekRule;
        readonly static DayOfWeek FirstDayOfWeek = Culture.DateTimeFormat.FirstDayOfWeek;

        private Week()
        {
            Today = DateTime.Today;

            Id = Calendar.GetWeekOfYear(Today, WeekRule, FirstDayOfWeek);
            Start = Today.FirstOfWeek();
            End = Today.EndOfWeek();
            Year = Today.Year;
            
            var Weeks = Year.WeeksByYear()
                .Select(w => w.Value)
                .ToList();             
        }
        private Week(int Id, int Year)
        {
            this.Id = Id;

            var Weeks = Year.WeeksByYear()
                .Select(w => w.Value)
                .ToList();

            var CurrentWeek = Weeks.FirstOrDefault(w => w.Id.Equals(Id));            

            Start = Today.FirstOfWeek();
            End = Today.EndOfWeek();                        
        }
        private Week(DateTime Date)
        {
            Today = Date;

            Id = Calendar.GetWeekOfYear(Today, WeekRule, FirstDayOfWeek);
            Start = Today.FirstOfWeek();
            End = Today.EndOfWeek();

            var dates = Enumerable
                .Range(1, 7)
                .Select(n => Start.AddDays(n - 1));

            foreach (var d in dates)
                WeekDays.Add(new Day(d));
        }

        public static Week Instance(DateTime Date) => new(Date);
        public static Week Instance(int Year, int WeekNumber) => new(WeekNumber, Year);

        public int Id { get; }
        public int Year { get; }       
        public DateTime Start { get; }
        public DateTime End { get; }
        public IList<Day> WeekDays { get; } = new List<Day>();
    }

    public static class WeekExtensions
    {
        readonly static CultureInfo Culture = new("en-US");
        readonly static Calendar Calendar = Culture.Calendar;
        readonly static CalendarWeekRule WeekRule = Culture.DateTimeFormat.CalendarWeekRule;
        readonly static DayOfWeek FirstDayOfWeek = Culture.DateTimeFormat.FirstDayOfWeek;

        public static DateTime AddWeek(this DateTime Date, int NumberWeeks)
        {
            int NumberDays = NumberWeeks * 7;
            var TempDate = Date.AddDays(NumberDays);
            Date = TempDate;

            return Date;
        }
        public static DateTime SubtractWeek(this DateTime Date, int NumberWeeks)
        {
            int NumberDays = (NumberWeeks * 7) * -1;
            var TempDate = Date.AddDays(NumberDays);
            Date = TempDate;

            return Date;
        }
        public static Week GetWeek(this DateTime Date) => Week.Instance(Date);
        public static Week NextWeek(this Week w) => Week.Instance(w.Start.AddWeek(1));
        public static Week PreviousWeek(this Week w) => Week.Instance(w.Start.AddWeek(-1));

        public static DateTime FirstOfWeek(this DateTime Date)
        {
            if (Date.DayOfWeek.Equals(DayOfWeek.Sunday))
                return Date;
            else
            {
                var DayNumber = (int)Date.DayOfWeek * -1;
                var TempDay = Date.AddDays(DayNumber);
                return TempDay;
            }
        }
        public static DateTime EndOfWeek(this DateTime Date)
        {
            if (Date.DayOfWeek.Equals(DayOfWeek.Saturday))
                return Date;
            else
            {
                var DayNumber = (int)Date.DayOfWeek + 6;
                var TempDay = Date.AddDays(DayNumber);
                return TempDay;
            }
        }

        public static IList<Week> WeeksOfMonth(this DateTime Date)
        {
            var Weeks = new List<Week>();
            var FirstDayOfMonth = new DateTime(Date.Year, Date.Month, 1);
            var daysInMonth = DateTime.DaysInMonth(Date.Year, Date.Month);

            IList<DateTime> dates = Enumerable
                .Range(1, daysInMonth)
                .Select(n => new DateTime(Date.Year, Date.Month, n))
                .ToList();

            var weekends = dates
                .Where(a => a.DayOfWeek.Equals(DayOfWeek.Monday))
                .ToList();

            var firstDate = weekends.FirstOrDefault();

            if (firstDate.Day != 1)
            {
                var beginingDifference = (firstDate.Day - FirstDayOfMonth.Day);

                if (beginingDifference > 0)
                {
                    var weekToAdd = weekends
                        .First()
                        .AddDays(-7);

                    var newWeek = Week.Instance(weekToAdd);

                    if (newWeek.WeekDays.Any(a => a.Month.Equals(Date.Month)))
                        Weeks.Add(newWeek);
                }
            }

            foreach (var w in weekends)
                Weeks.Add(Week.Instance(w));

            if (weekends.Last().Day < daysInMonth)
            {
                var endDifference = (daysInMonth - weekends.Last().Day);
                if (endDifference > 1)
                {
                    var weekToAdd = weekends
                        .Last()
                        .AddDays(7);

                    var newWeek = Week.Instance(weekToAdd);

                    if (newWeek.WeekDays.Any(a => a.Month.Equals(Date.Month)))
                        Weeks.Add(newWeek);
                }
            }       

            return Weeks;
        }

        public static SortedDictionary<int, Week> WeeksByYear(this int Year)
        {
            SortedDictionary<int, Week> WeekDictionary = new();

            DateTime FirstDayOfYear = new(Year, 1, 1);
            int TotalDaysInYear = Calendar.GetDaysInYear(Year);

            int Index = 0;
            int WeekIndex = 0;
            var TempDay = FirstDayOfYear;
            while (Index <= TotalDaysInYear)
            {
                if (TempDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    WeekDictionary.TryAdd(WeekIndex, Week.Instance(TempDay));
                    WeekIndex++;
                }
                TempDay = TempDay.AddDays(1);
                Index++;
            }
            return WeekDictionary;
        }        
    }
}
