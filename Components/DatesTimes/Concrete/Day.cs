using Components.DatesTimes.Concrete;
using System;
using System.Linq;

namespace Components.DatesAndTimes
{
    public class Day
    {
        readonly DateTime Today;

        public Day()
        {
            Today = DateTime.Today;
            Id = Today.DayOfYear;
            Name = Today.DayOfWeek.ToString();
            DayOfYear = Today.DayOfYear;
            DayOfMonth = Today.Day;
            DayOfWeek = Today.DayOfWeek;
            Year = new Year(Today.Year);
        }
        public Day(DateTime date)
        {
            Today = date;
            Id = Today.DayOfYear;
            Name = Today.DayOfWeek.ToString();
            DayOfYear = Today.DayOfYear;
            DayOfMonth = Today.Day;
            DayOfWeek = Today.DayOfWeek;

            Month = Today.Month; 
            Year = new Year(Today.Year);
        }

        public int Id { get; }
        public string Name { get; }
        public int DayOfYear { get; }
        public int DayOfMonth { get; }
        public int Month { get; }
        public DayOfWeek DayOfWeek { get; }
        public Year Year { get; }

        public Day NextDay() => new(Today.AddDays(1));
        public Day PreviousDay() => new(Today.AddDays(-1));

        public static implicit operator DayOfWeek(Day d) => d.DayOfWeek;
        public static implicit operator DateTime(Day d) => d.Today;

        public override string ToString()
        {
            return Today.ToShortDateString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Day d)            
                if (Id == d.Id && Year.Number == d.Year.Number)
                    return true;                            

            return false;
        }

        public override int GetHashCode()
        {
           return base.GetHashCode();
        }
    }

    public static class DayExtensions
    {
        public static Day NextDay(this Day d) => d.NextDay();
        public static Day PreviousDay(this Day d) => d.PreviousDay();
    }
}