using System;

public class Clock : IEquatable<Clock>
{
    private int _hours;
    private int _minutes;
    public Clock(int hours, int minutes)
    {
        _hours= (hours + minutes / 60) % 24;
        if (_hours < 0) _hours = 24 + _hours;

        _minutes= minutes % 60;
        if (_minutes < 0)
        {
            _minutes = 60 + _minutes;
            _hours--;
        }
    }

    public Clock Add(int minutesToAdd)
    {
        int hoursToAdd = minutesToAdd / 60;
        minutesToAdd %= 60;

        int newMinutes;
        if ((minutesToAdd + _minutes) > 59)
        {
            hoursToAdd += (minutesToAdd + _minutes) / 60;
            newMinutes = (minutesToAdd + _minutes) % 60;
        }
        else
        {
            newMinutes = _minutes + minutesToAdd;
        }

        int newHours = (hoursToAdd + _hours) % 24;

        return new Clock(newHours, newMinutes);
    }

    public bool Equals(Clock other) => _hours == other._hours && _minutes == other._minutes;

    public override string ToString() => $"{_hours:00}:{_minutes:00}";

    public Clock Subtract(int minutesToSubtract)
    {
        int hoursToSubtract = minutesToSubtract / 60;
        minutesToSubtract %= 60;

        int newMinutes;
        if (minutesToSubtract > _minutes)
        {
            hoursToSubtract++;
            newMinutes = 60 - (minutesToSubtract - _minutes);
        }
        else
        {
            newMinutes = _minutes - minutesToSubtract;
        }

        if (hoursToSubtract > _hours)
        {
            hoursToSubtract = hoursToSubtract % 24 - 24 ;
        }

        int newHours = (_hours - hoursToSubtract) % 24;

        return new Clock(newHours, newMinutes);
    }
}
