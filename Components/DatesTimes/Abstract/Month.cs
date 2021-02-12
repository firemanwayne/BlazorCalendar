using Components.DatesTimes.Concrete;
using System;
using System.Collections.Generic;

namespace Components.DatesAndTimes
{
    public abstract class MonthBase
    {
        readonly DateTime Today;
        protected MonthBase(string name, int number)
        {
            Name = name;
            Number = number;
            Today = new DateTime(DateTime.Today.Year, number, 1);
            Abbreviation = Today.ToString("MMM");
            Year = new Year(Today.Year);
            Weeks = Today.WeeksOfMonth();
        }
        protected MonthBase(string name, int number, int year)
        {
            Name = name;
            Number = number;
            Today = new DateTime(year, number, 1);
            Abbreviation = Today.ToString("MMM");
            Year = new Year(Today.Year);
            Weeks = Today.WeeksOfMonth();
        }

        public Year Year { get; }
        public int Number { get; }
        public string Name { get; }
        public string Abbreviation { get; }
        public IEnumerable<Week> Weeks { get; } = new List<Week>();

        public abstract MonthBase NextMonth();
        public abstract MonthBase PreviousMonth();
    }

    public abstract class Month<T> : MonthBase
    {
        protected Month(int month) : base(typeof(T).Name, month)
        { }

        protected Month(int number, int year) : base(typeof(T).Name, number, year)
        { }        
    }    
}
