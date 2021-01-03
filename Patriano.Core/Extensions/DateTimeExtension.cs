using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Patriano.Core.Extensions
{
    public static class DateTimeExtension
    {
        public static string MonthString(this DateTime date, string culture = "de")
        {
            if (date == null)
            {
                return "N/A";
            }

            return date.ToString("MMMM", CultureInfo.CreateSpecificCulture(culture));
        }

        public static DateTime FirstOfNextMonth(this DateTime date) => new DateTime(date.AddMonths(1).Year, date.AddMonths(1).Month, 1);

        public static DateTime LastDayInMonth(this DateTime date) => date.FirstOfNextMonth().AddDays(-1);

        public static DateTime FirstOfPreviousMonth(this DateTime date) => date.FirstOfNextMonth().AddMonths(-2);

        public static IEnumerable<DateTime> AllDaysInMonth(this DateTime? date)
        {
            if (date is null)
            {
                return Enumerable.Empty<DateTime>();
            }
            var year = date.Value.Year;
            var month = date.Value.Month;
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))  // Days: 1, 2 ... 31 etc.
                    .Select(day => new DateTime(year, month, day)) // Map each day to a date
                    .ToList(); // Load dates into a list
        }

        public static bool IsBeginOfWeek(this DateTime date, DayOfWeek firstOfWeek = DayOfWeek.Monday)
        {
            return date.DayOfWeek == firstOfWeek;
        }

        public static DateTime FirstDayOfWeek(this DateTime date, DayOfWeek firstOfWeek = DayOfWeek.Monday)
        {
            var curDate = date;
            while (!curDate.IsBeginOfWeek(firstOfWeek))
            {
                curDate = curDate.AddDays(-1);
            }
            return curDate;
        }

        public static DateTime? FirstDayOfWeek(this DateTime? date)
        {
            if (!date.HasValue)
            {
                return null;
            }

            return date.Value.FirstDayOfWeek();
        }

        public static DateTime LastDayOfWeek(this DateTime date)
        {
            var curDate = date;
            while (!curDate.IsEndOfWeek())
            {
                curDate = curDate.AddDays(1);
            }
            return curDate;
        }

        public static DateTime? LastDayOfWeek(this DateTime? date)
        {
            if (!date.HasValue)
            {
                return null;
            }

            return date.Value.LastDayOfWeek();
        }

        public static bool IsEndOfWeek(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsEdgeWeekDay(this DateTime date)
        {
            return date.IsBeginOfWeek() || date.IsEndOfWeek();
        }

        public static string ToGermanDateTimeString(this DateTime date)
        {
            return date.ToString("G");
        }
    }
}