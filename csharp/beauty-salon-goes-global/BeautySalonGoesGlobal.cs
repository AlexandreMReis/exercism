using System;
using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    private static string GetZoneIdByLocation(Location location)
    {
        var zoneId = string.Empty;

        switch (location)
        {
            case Location.NewYork:
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    zoneId = "America/New_York";
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    zoneId = "Eastern Standard Time";
                }
                break;

            case Location.London:
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    zoneId = "Europe/London";
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    zoneId = "GMT Standard Time";
                }
                break;

            case Location.Paris:
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    zoneId = "Europe/Paris";
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    zoneId = "W. Europe Standard Time";
                }
                break;
        }

        return zoneId;
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var success = DateTime.TryParse(appointmentDateDescription, out DateTime localDateTime);
        if (!success) return DateTime.MinValue;

        return TimeZoneInfo.ConvertTimeToUtc(localDateTime, TimeZoneInfo.FindSystemTimeZoneById(GetZoneIdByLocation(location)));
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        switch (alertLevel)
        {
            case AlertLevel.Early:
                return appointment.AddDays(-1);
            case AlertLevel.Standard:
                return appointment.AddMinutes(-105);
            case AlertLevel.Late:
                return appointment.AddMinutes(-30);
            default:
                return appointment;
        }
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var utcDate = Schedule(dt.ToString("MM/dd/yyyy HH:mm:ss"), location);
        var originalDateIsDaylightSavingTime = TimeZoneInfo.FindSystemTimeZoneById(GetZoneIdByLocation(location)).IsDaylightSavingTime(utcDate);
        var beforeSevenDaysDateIsDaylightSavingTime = TimeZoneInfo.FindSystemTimeZoneById(GetZoneIdByLocation(location)).IsDaylightSavingTime(utcDate.AddDays(-7));

        return originalDateIsDaylightSavingTime != beforeSevenDaysDateIsDaylightSavingTime;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var output = DateTime.MinValue;
        switch (location)
        {
            case Location.London:
            case Location.Paris:

                if(DateTime.TryParseExact(dtStr, "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out DateTime aux))
                {
                    output = aux;
                }
                break;
            case Location.NewYork:
                if (DateTime.TryParseExact(dtStr, "MM/dd/yyyy HH:mm:ss", new CultureInfo("en-US"), DateTimeStyles.None, out aux))
                {
                    output = aux;
                }
                break;
            default:
                break;

        }

        return output;
    }
}
