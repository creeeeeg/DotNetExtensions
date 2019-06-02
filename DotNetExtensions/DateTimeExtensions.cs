using System;
using System.Collections.Generic;
using System.Text;

[Serializable]
public static class DateTimeExtensions
{
    public static string ToShort(this DateTime value
        , string OutOfRangeDateFormat = "MM/dd/yyyy HH:mm tt"
        , string YesterdayDateFormat = "HH:mm tt"
        , string TomorrowDateFormat = "HH:mm tt"
        , string prefix = "in "
        , string suffix = " ago"
        , bool addFlair = true)
    {
        var now = DateTime.Now;
        var output = string.Empty;
        var diff = now - value;
        var secs = Math.Abs(Math.Round(diff.TotalSeconds));
        var mins = Math.Abs(Math.Round(diff.TotalMinutes));
        var hrs = Math.Abs(Math.Round(diff.TotalHours));
        var yesterday = DateTime.Today.AddDays(-1);
        var tomorrow = DateTime.Today.AddDays(1);

        var flair = addFlair ? (prefix, suffix) : (prefix: string.Empty, suffix: string.Empty);

        if (secs < 60)
        {
            output = mins.ToString() + "s";
            output = (diff.TotalSeconds > 0) ? output + flair.suffix : flair.prefix + output;
        }
        else if (mins < 60)
        {
            output = mins.ToString() + "m";
            output = (diff.TotalMinutes > 0) ? output + flair.suffix : flair.prefix + output;
        }
        else if (hrs > 1 && hrs < 24 && diff != TimeSpan.FromDays(1))
        {
            output = hrs.ToString() + "h";
            output = (diff.TotalHours > 0) ? output + flair.suffix : flair.prefix + output;
        }
        else if (value >= yesterday && value <= tomorrow)
        {
            output = $"Yesterday {value.ToString(YesterdayDateFormat)}";
        }
        else if (value > tomorrow)
        {
            output = $"Tomorrow {value.ToString(TomorrowDateFormat)}";
        }
        else
        {
            output = value.ToString(OutOfRangeDateFormat);
        }
        return output;
    }
}
