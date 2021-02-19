using System;
using System.Collections.Generic;
using System.Linq;

namespace Components.DatesAndTimes
{
    public struct DailyTimeIntervals
    {
        private const int NumberHoursInDay = 24;
        private const int NumberMonthsInQuarter = 3;

        public int Id { get; private set; }
        public int Hour { get; private set; }
        public int Minutes { get; private set; }
        public string TimeAsString { get; private set; }
        public TimeSpan TotalTimeSpan { get => (TimeSpan.FromHours(Hour) + TimeSpan.FromMinutes(Minutes)); }
        public decimal HourMinuteCombined { get => Convert.ToDecimal(TimeSpan.FromMinutes(TimeSpan.FromHours(Hour).TotalMinutes + TimeSpan.FromMinutes(Minutes).TotalMinutes).TotalHours); }

        public static List<DailyTimeIntervals> Times = new List<DailyTimeIntervals>()
        {
                    new DailyTimeIntervals(){ Id = 1, Hour = 00, Minutes = 00, TimeAsString = $"{00}:{00}" },
                    new DailyTimeIntervals(){ Id = 2, Hour = 00, Minutes = 30, TimeAsString = $"{00}:{30}"  },
                    new DailyTimeIntervals(){ Id = 3, Hour = 01, Minutes = 00, TimeAsString = $"{01}:{00}"  },
                    new DailyTimeIntervals(){ Id = 4, Hour = 01, Minutes = 30, TimeAsString = $"{01}:{30}"  },
                    new DailyTimeIntervals(){ Id = 5, Hour = 02, Minutes = 00, TimeAsString = $"{02}:{00}"  },
                    new DailyTimeIntervals(){ Id = 6, Hour = 02, Minutes = 30, TimeAsString = $"{02}:{30}"  },
                    new DailyTimeIntervals(){ Id = 7, Hour = 03, Minutes = 00, TimeAsString = $"{03}:{00}"  },
                    new DailyTimeIntervals(){ Id = 8, Hour = 03, Minutes = 30, TimeAsString = $"{03}:{30}"  },
                    new DailyTimeIntervals(){ Id = 9, Hour = 04, Minutes = 00, TimeAsString = $"{04}:{00}"  },
                    new DailyTimeIntervals(){ Id = 10, Hour = 04, Minutes = 30, TimeAsString = $"{04}:{30}"  },
                    new DailyTimeIntervals(){ Id = 11, Hour = 05, Minutes = 00, TimeAsString = $"{05}:{00}"  },
                    new DailyTimeIntervals(){ Id = 12, Hour = 05, Minutes = 30, TimeAsString = $"{05}:{30}"  },
                    new DailyTimeIntervals(){ Id = 13, Hour = 06, Minutes = 00, TimeAsString = $"{06}:{00}"  },
                    new DailyTimeIntervals(){ Id = 14, Hour = 06, Minutes = 30, TimeAsString = $"{06}:{30}"  },
                    new DailyTimeIntervals(){ Id = 15, Hour = 07, Minutes = 00, TimeAsString = $"{07}:{00}"  },
                    new DailyTimeIntervals(){ Id = 16, Hour = 07, Minutes = 30, TimeAsString = $"{07}:{30}"  },
                    new DailyTimeIntervals(){ Id = 17, Hour = 08, Minutes = 00, TimeAsString = $"{08}:{00}"  },
                    new DailyTimeIntervals(){ Id = 18, Hour = 08, Minutes = 30, TimeAsString = $"{08}:{30}"  },
                    new DailyTimeIntervals(){ Id = 19, Hour = 09, Minutes = 00, TimeAsString = $"{09}:{00}"  },
                    new DailyTimeIntervals(){ Id = 20, Hour = 09, Minutes = 30, TimeAsString = $"{09}:{30}"  },
                    new DailyTimeIntervals(){ Id = 21, Hour = 10, Minutes = 00, TimeAsString = $"{10}:{00}"  },
                    new DailyTimeIntervals(){ Id = 22, Hour = 10, Minutes = 30, TimeAsString = $"{10}:{30}"  },
                    new DailyTimeIntervals(){ Id = 23, Hour = 11, Minutes = 00, TimeAsString = $"{11}:{00}"  },
                    new DailyTimeIntervals(){ Id = 24, Hour = 11, Minutes = 30, TimeAsString = $"{11}:{30}"  },
                    new DailyTimeIntervals(){ Id = 25, Hour = 12, Minutes = 00, TimeAsString = $"{12}:{00}"  },
                    new DailyTimeIntervals(){ Id = 26, Hour = 12, Minutes = 30, TimeAsString = $"{12}:{30}"  },
                    new DailyTimeIntervals(){ Id = 27, Hour = 13, Minutes = 00, TimeAsString = $"{13}:{00}"  },
                    new DailyTimeIntervals(){ Id = 28, Hour = 13, Minutes = 30, TimeAsString = $"{13}:{30}"  },
                    new DailyTimeIntervals(){ Id = 29, Hour = 14, Minutes = 00, TimeAsString = $"{14}:{00}"  },
                    new DailyTimeIntervals(){ Id = 30, Hour = 14, Minutes = 30, TimeAsString = $"{14}:{30}"  },
                    new DailyTimeIntervals(){ Id = 31, Hour = 15, Minutes = 00, TimeAsString = $"{15}:{00}"  },
                    new DailyTimeIntervals(){ Id = 32, Hour = 15, Minutes = 30, TimeAsString = $"{15}:{30}"  },
                    new DailyTimeIntervals(){ Id = 33, Hour = 16, Minutes = 00, TimeAsString = $"{16}:{00}"  },
                    new DailyTimeIntervals(){ Id = 34, Hour = 16, Minutes = 30, TimeAsString = $"{16}:{30}"  },
                    new DailyTimeIntervals(){ Id = 35, Hour = 17, Minutes = 00, TimeAsString = $"{17}:{00}"  },
                    new DailyTimeIntervals(){ Id = 36, Hour = 17, Minutes = 30, TimeAsString = $"{17}:{30}"  },
                    new DailyTimeIntervals(){ Id = 37, Hour = 18, Minutes = 00, TimeAsString = $"{18}:{00}"  },
                    new DailyTimeIntervals(){ Id = 38, Hour = 18, Minutes = 30, TimeAsString = $"{18}:{30}"  },
                    new DailyTimeIntervals(){ Id = 39, Hour = 19, Minutes = 00, TimeAsString = $"{19}:{00}"  },
                    new DailyTimeIntervals(){ Id = 40, Hour = 19, Minutes = 30, TimeAsString = $"{19}:{30}"  },
                    new DailyTimeIntervals(){ Id = 41, Hour = 20, Minutes = 00, TimeAsString = $"{20}:{00}"  },
                    new DailyTimeIntervals(){ Id = 42, Hour = 20, Minutes = 30, TimeAsString = $"{20}:{30}"  },
                    new DailyTimeIntervals(){ Id = 43, Hour = 21, Minutes = 00, TimeAsString = $"{21}:{00}"  },
                    new DailyTimeIntervals(){ Id = 44, Hour = 21, Minutes = 30, TimeAsString = $"{21}:{30}"  },
                    new DailyTimeIntervals(){ Id = 45, Hour = 22, Minutes = 00, TimeAsString = $"{22}:{00}"  },
                    new DailyTimeIntervals(){ Id = 46, Hour = 22, Minutes = 30, TimeAsString = $"{22}:{30}"  },
                    new DailyTimeIntervals(){ Id = 47, Hour = 23, Minutes = 00, TimeAsString = $"{23}:{00}"  },
                    new DailyTimeIntervals(){ Id = 48, Hour = 23, Minutes = 30, TimeAsString = $"{23}:{30}"  }
        };

        public static TimeSpan GetTotalTimeSpanFromId(int Id) => Times.Find(i => i.Id == Id).TotalTimeSpan;
        public static DailyTimeIntervals GetDailyTimeIntervalFromId(int Id) => Times.Find(i => i.Id == Id);
        public static DailyTimeIntervals GetTimeIntervalFromHourMinute(int Hour, int Minutes)
        {
            int min = Minutes, hour = Hour;

            if (Hour > 23 && Minutes > 59)
            {
                if (Hour > 23) throw new ArgumentException("Hour cannot be greater than 23");
                if (Minutes > 59) throw new ArgumentException("Minutes cannot be greater than 59");
            }

            if (Minutes < 16) min = 0;

            else if (Minutes > 15 && Minutes < 45) min = 30;

            else if (Minutes >= 45)
            {
                min = 0;
                if (Hour < 23) hour++;
                else if (Hour == 23) hour = 0;
            }

            return Times.Single(t => t.Hour.Equals(Hour) && t.Minutes.Equals(Minutes));
        }
        public static IEnumerable<DailyTimeIntervals> TimeIntervals = Times;
        public static IEnumerable<DailyTimeIntervals> SpecificTimeIntervals(int StartHour, int StopHour)
        {
            if (StartHour < StopHour)
                return TimeIntervals.Where(t => t.Hour >= StartHour && t.Hour <= StopHour)
                    .OrderBy(t => t.Id)
                    .ToList();
            else
                return TimeIntervals;
        }
        public static decimal GetTime(int TimeId)
        {
            DailyTimeIntervals TimeIntervalObject = GetDailyTimeIntervalFromId(TimeId);
            double TimeOfDay = TimeSpan.FromMinutes(TimeSpan.FromHours(TimeIntervalObject.Hour).TotalMinutes + TimeSpan.FromMinutes(TimeIntervalObject.Minutes).TotalMinutes).TotalHours;

            return Convert.ToDecimal(TimeOfDay);
        }
        public static double Duration(int StartId, int StopId)
        {
            DailyTimeIntervals StartTimeObject = GetDailyTimeIntervalFromId(StartId);
            DailyTimeIntervals StopTimeObject = GetDailyTimeIntervalFromId(StopId);

            TimeSpan Start = (TimeSpan.FromHours(StartTimeObject.Hour) + TimeSpan.FromMinutes(StartTimeObject.Minutes));
            TimeSpan Stop = (TimeSpan.FromHours(StopTimeObject.Hour) + TimeSpan.FromMinutes(StopTimeObject.Minutes));

            double Duration = 0;
            if (Stop > Start)
                Duration = ((Stop.TotalHours) - (Start.TotalHours));
            if (Stop < Start)
                Duration = ((Stop.TotalHours) - (Start.TotalHours)) + NumberHoursInDay;
            if (Stop == Start)
                Duration = NumberHoursInDay;

            return Duration;
        }
        public static DateTime GetDateTime(string Date, int TimeId)
        {
            DailyTimeIntervals TimeIntervalObject = GetDailyTimeIntervalFromId(TimeId);
            DateTime DateObject = DateTime.Parse(Date);
            return new DateTime(DateObject.Year, DateObject.Month, DateObject.Day, TimeIntervalObject.Hour, TimeIntervalObject.Minutes, 0);
        }
        public static DateTime GetDateTime(DateTime Date, int TimeId)
        {
            DailyTimeIntervals TimeIntervalObject = GetDailyTimeIntervalFromId(TimeId);
            return new DateTime(Date.Year, Date.Month, Date.Day, TimeIntervalObject.Hour, TimeIntervalObject.Minutes, 0);
        }
        private static readonly List<DailyTimeIntervals> QuarterTimes = new List<DailyTimeIntervals>()
        {
            //00:00
            new DailyTimeIntervals(){ Id = 1, Hour = 00, Minutes = 00, TimeAsString = $"{00}:{00}" },
            new DailyTimeIntervals(){ Id = 2, Hour = 00, Minutes = 15, TimeAsString = $"{00}:{15}" },
            new DailyTimeIntervals(){ Id = 3, Hour = 00, Minutes = 30, TimeAsString = $"{00}:{30}" },
            new DailyTimeIntervals(){ Id = 4, Hour = 00, Minutes = 45, TimeAsString = $"{00}:{45}" },
            //01:00
            new DailyTimeIntervals(){ Id = 5, Hour = 01, Minutes = 00, TimeAsString = $"{01}:{00}" },
            new DailyTimeIntervals(){ Id = 6, Hour = 01, Minutes = 15, TimeAsString = $"{01}:{15}" },
            new DailyTimeIntervals(){ Id = 7, Hour = 01, Minutes = 30, TimeAsString = $"{01}:{30}" },
            new DailyTimeIntervals(){ Id = 8, Hour = 01, Minutes = 45, TimeAsString = $"{01}:{45}" },
            //02:00
            new DailyTimeIntervals(){ Id = 9, Hour = 02, Minutes = 00, TimeAsString = $"{02}:{00}" },
            new DailyTimeIntervals(){ Id = 10, Hour = 02, Minutes = 15, TimeAsString = $"{02}:{15}" },
            new DailyTimeIntervals(){ Id = 11, Hour = 02, Minutes = 30, TimeAsString = $"{02}:{30}" },
            new DailyTimeIntervals(){ Id = 12, Hour = 02, Minutes = 45, TimeAsString = $"{02}:{45}" },
            //03:00
            new DailyTimeIntervals(){ Id = 13, Hour = 03, Minutes = 00, TimeAsString = $"{03}:{00}" },
            new DailyTimeIntervals(){ Id = 14, Hour = 03, Minutes = 15, TimeAsString = $"{03}:{15}" },
            new DailyTimeIntervals(){ Id = 15, Hour = 03, Minutes = 30, TimeAsString = $"{03}:{30}" },
            new DailyTimeIntervals(){ Id = 16, Hour = 03, Minutes = 45, TimeAsString = $"{03}:{45}" },
            //04:00
            new DailyTimeIntervals(){ Id = 17, Hour = 04, Minutes = 00, TimeAsString = $"{04}:{00}" },
            new DailyTimeIntervals(){ Id = 18, Hour = 04, Minutes = 15, TimeAsString = $"{04}:{15}" },
            new DailyTimeIntervals(){ Id = 19, Hour = 04, Minutes = 30, TimeAsString = $"{04}:{30}" },
            new DailyTimeIntervals(){ Id = 20, Hour = 04, Minutes = 45, TimeAsString = $"{04}:{45}" },
            //05:00
            new DailyTimeIntervals(){ Id = 21, Hour = 05, Minutes = 00, TimeAsString = $"{05}:{00}" },
            new DailyTimeIntervals(){ Id = 22, Hour = 05, Minutes = 15, TimeAsString = $"{05}:{15}" },
            new DailyTimeIntervals(){ Id = 23, Hour = 05, Minutes = 30, TimeAsString = $"{05}:{30}" },
            new DailyTimeIntervals(){ Id = 24, Hour = 05, Minutes = 45, TimeAsString = $"{05}:{45}" },
            //06:00
            new DailyTimeIntervals(){ Id = 25, Hour = 06, Minutes = 00, TimeAsString = $"{06}:{00}" },
            new DailyTimeIntervals(){ Id = 26, Hour = 06, Minutes = 15, TimeAsString = $"{06}:{15}" },
            new DailyTimeIntervals(){ Id = 27, Hour = 06, Minutes = 30, TimeAsString = $"{06}:{30}" },
            new DailyTimeIntervals(){ Id = 28, Hour = 06, Minutes = 45, TimeAsString = $"{06}:{45}" },
            //07:00
            new DailyTimeIntervals(){ Id = 29, Hour = 07, Minutes = 00, TimeAsString = $"{07}:{00}" },
            new DailyTimeIntervals(){ Id = 30, Hour = 07, Minutes = 15, TimeAsString = $"{07}:{15}" },
            new DailyTimeIntervals(){ Id = 31, Hour = 07, Minutes = 30, TimeAsString = $"{07}:{30}" },
            new DailyTimeIntervals(){ Id = 32, Hour = 07, Minutes = 45, TimeAsString = $"{07}:{45}" },
            //08:00
            new DailyTimeIntervals(){ Id = 33, Hour = 08, Minutes = 00, TimeAsString = $"{08}:{00}" },
            new DailyTimeIntervals(){ Id = 34, Hour = 08, Minutes = 15, TimeAsString = $"{08}:{15}" },
            new DailyTimeIntervals(){ Id = 35, Hour = 08, Minutes = 30, TimeAsString = $"{08}:{30}" },
            new DailyTimeIntervals(){ Id = 36, Hour = 08, Minutes = 45, TimeAsString = $"{08}:{45}" },
            //09:00
            new DailyTimeIntervals(){ Id = 37, Hour = 09, Minutes = 00, TimeAsString = $"{09}:{00}" },
            new DailyTimeIntervals(){ Id = 38, Hour = 09, Minutes = 15, TimeAsString = $"{09}:{15}" },
            new DailyTimeIntervals(){ Id = 39, Hour = 09, Minutes = 30, TimeAsString = $"{09}:{30}" },
            new DailyTimeIntervals(){ Id = 40, Hour = 09, Minutes = 45, TimeAsString = $"{09}:{45}" },
            //10:00
            new DailyTimeIntervals(){ Id = 41, Hour = 10, Minutes = 00, TimeAsString = $"{10}:{00}" },
            new DailyTimeIntervals(){ Id = 42, Hour = 10, Minutes = 15, TimeAsString = $"{10}:{15}" },
            new DailyTimeIntervals(){ Id = 43, Hour = 10, Minutes = 30, TimeAsString = $"{10}:{30}" },
            new DailyTimeIntervals(){ Id = 44, Hour = 10, Minutes = 45, TimeAsString = $"{10}:{45}" },
            //11:00                   
            new DailyTimeIntervals(){ Id = 45, Hour = 11, Minutes = 00, TimeAsString = $"{11}:{00}" },
            new DailyTimeIntervals(){ Id = 46, Hour = 11, Minutes = 15, TimeAsString = $"{11}:{15}" },
            new DailyTimeIntervals(){ Id = 47, Hour = 11, Minutes = 30, TimeAsString = $"{11}:{30}" },
            new DailyTimeIntervals(){ Id = 48, Hour = 11, Minutes = 45, TimeAsString = $"{11}:{45}" },
            //12:00
            new DailyTimeIntervals(){ Id = 49, Hour = 12, Minutes = 00, TimeAsString = $"{12}:{00}" },
            new DailyTimeIntervals(){ Id = 50, Hour = 12, Minutes = 15, TimeAsString = $"{12}:{15}" },
            new DailyTimeIntervals(){ Id = 51, Hour = 12, Minutes = 30, TimeAsString = $"{12}:{30}" },
            new DailyTimeIntervals(){ Id = 52, Hour = 12, Minutes = 45, TimeAsString = $"{12}:{45}" },
            //13:00
            new DailyTimeIntervals(){ Id = 53, Hour = 13, Minutes = 00, TimeAsString = $"{13}:{00}" },
            new DailyTimeIntervals(){ Id = 54, Hour = 13, Minutes = 15, TimeAsString = $"{13}:{15}" },
            new DailyTimeIntervals(){ Id = 55, Hour = 13, Minutes = 30, TimeAsString = $"{13}:{30}" },
            new DailyTimeIntervals(){ Id = 56, Hour = 13, Minutes = 45, TimeAsString = $"{13}:{45}" },
            //14:00
            new DailyTimeIntervals(){ Id = 57, Hour = 14, Minutes = 00, TimeAsString = $"{14}:{00}" },
            new DailyTimeIntervals(){ Id = 58, Hour = 14, Minutes = 15, TimeAsString = $"{14}:{15}" },
            new DailyTimeIntervals(){ Id = 59, Hour = 14, Minutes = 30, TimeAsString = $"{14}:{30}" },
            new DailyTimeIntervals(){ Id = 60, Hour = 14, Minutes = 45, TimeAsString = $"{14}:{45}" },
            //15:00
            new DailyTimeIntervals(){ Id = 61, Hour = 15, Minutes = 00, TimeAsString = $"{15}:{00}" },
            new DailyTimeIntervals(){ Id = 62, Hour = 15, Minutes = 15, TimeAsString = $"{15}:{15}" },
            new DailyTimeIntervals(){ Id = 63, Hour = 15, Minutes = 30, TimeAsString = $"{15}:{30}" },
            new DailyTimeIntervals(){ Id = 64, Hour = 15, Minutes = 45, TimeAsString = $"{15}:{45}" },
            //16:00
            new DailyTimeIntervals(){ Id = 65, Hour = 16, Minutes = 00, TimeAsString = $"{16}:{00}" },
            new DailyTimeIntervals(){ Id = 66, Hour = 16, Minutes = 15, TimeAsString = $"{16}:{15}" },
            new DailyTimeIntervals(){ Id = 67, Hour = 16, Minutes = 30, TimeAsString = $"{16}:{30}" },
            new DailyTimeIntervals(){ Id = 68, Hour = 16, Minutes = 45, TimeAsString = $"{16}:{45}" },
            //17:00
            new DailyTimeIntervals(){ Id = 69, Hour = 17, Minutes = 00, TimeAsString = $"{17}:{00}" },
            new DailyTimeIntervals(){ Id = 70, Hour = 17, Minutes = 15, TimeAsString = $"{17}:{15}" },
            new DailyTimeIntervals(){ Id = 71, Hour = 17, Minutes = 30, TimeAsString = $"{17}:{30}" },
            new DailyTimeIntervals(){ Id = 72, Hour = 17, Minutes = 45, TimeAsString = $"{17}:{45}" },
            //18:00
            new DailyTimeIntervals(){ Id = 73, Hour = 18, Minutes = 00, TimeAsString = $"{18}:{00}" },
            new DailyTimeIntervals(){ Id = 74, Hour = 18, Minutes = 15, TimeAsString = $"{18}:{15}" },
            new DailyTimeIntervals(){ Id = 75, Hour = 18, Minutes = 30, TimeAsString = $"{18}:{30}" },
            new DailyTimeIntervals(){ Id = 76, Hour = 18, Minutes = 45, TimeAsString = $"{18}:{45}" },
            //19:00
            new DailyTimeIntervals(){ Id = 77, Hour = 19, Minutes = 00, TimeAsString = $"{19}:{00}" },
            new DailyTimeIntervals(){ Id = 78, Hour = 19, Minutes = 15, TimeAsString = $"{19}:{15}" },
            new DailyTimeIntervals(){ Id = 79, Hour = 19, Minutes = 30, TimeAsString = $"{19}:{30}" },
            new DailyTimeIntervals(){ Id = 80, Hour = 19, Minutes = 45, TimeAsString = $"{19}:{45}" },
            //20:00
            new DailyTimeIntervals(){ Id = 81, Hour = 20, Minutes = 00, TimeAsString = $"{20}:{00}" },
            new DailyTimeIntervals(){ Id = 82, Hour = 00, Minutes = 15, TimeAsString = $"{20}:{15}" },
            new DailyTimeIntervals(){ Id = 83, Hour = 00, Minutes = 30, TimeAsString = $"{20}:{30}" },
            new DailyTimeIntervals(){ Id = 84, Hour = 00, Minutes = 45, TimeAsString = $"{20}:{45}" },
            //21:00
            new DailyTimeIntervals(){ Id = 85, Hour = 21, Minutes = 00, TimeAsString = $"{21}:{00}" },
            new DailyTimeIntervals(){ Id = 86, Hour = 21, Minutes = 15, TimeAsString = $"{21}:{15}" },
            new DailyTimeIntervals(){ Id = 87, Hour = 21, Minutes = 30, TimeAsString = $"{21}:{30}" },
            new DailyTimeIntervals(){ Id = 88, Hour = 21, Minutes = 45, TimeAsString = $"{21}:{45}" },
            //22:00
            new DailyTimeIntervals(){ Id = 89, Hour = 22, Minutes = 00, TimeAsString = $"{22}:{00}" },
            new DailyTimeIntervals(){ Id = 90, Hour = 22, Minutes = 15, TimeAsString = $"{22}:{15}" },
            new DailyTimeIntervals(){ Id = 91, Hour = 22, Minutes = 30, TimeAsString = $"{22}:{30}" },
            new DailyTimeIntervals(){ Id = 92, Hour = 22, Minutes = 45, TimeAsString = $"{22}:{45}" },
            //23:00
            new DailyTimeIntervals(){ Id = 93, Hour = 23, Minutes = 00, TimeAsString = $"{23}:{00}" },
            new DailyTimeIntervals(){ Id = 94, Hour = 23, Minutes = 15, TimeAsString = $"{23}:{15}" },
            new DailyTimeIntervals(){ Id = 95, Hour = 23, Minutes = 30, TimeAsString = $"{23}:{30}" },
            new DailyTimeIntervals(){ Id = 96, Hour = 23, Minutes = 45, TimeAsString = $"{23}:{45}" },
        };
    }
}