using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackingBlazor.Shared.Extensions
{
    public static class TimeSpanExtension
    {
        public static string HoursMinutesFormat(this TimeSpan span)
        {
            return $"{((int)span.TotalHours):00}:{((int)(span.TotalMinutes % 60)):00}";
        }

        public static string HoursMinutesSecondsFormat(this TimeSpan span)
        {
            return $"{span.HoursMinutesFormat()}:{(span.TotalSeconds % 60):00}";
        }

        public static TimeSpan? Substract(this TimeSpan? span, params TimeSpan?[] spans)
        {
            if(spans?.Any() != true || !span.HasValue)
            {
                return span;
            }
            var resultSpan = new TimeSpan(span.Value.Ticks);
            foreach(var curSpan in spans)
            {
                if (!curSpan.HasValue)
                {
                    continue;
                }
                if(resultSpan < curSpan)
                {
                    resultSpan = new TimeSpan(0);
                    break;
                }
                resultSpan -= curSpan.Value;
            }
            return resultSpan;
        }
    }
}
