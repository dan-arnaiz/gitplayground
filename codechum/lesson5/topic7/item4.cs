using System;

public abstract class ScheduleStructure
{
    private int currentPeriodNumber;

    public ScheduleStructure(int currentPeriodNumber)
    {
        this.currentPeriodNumber = currentPeriodNumber;
    }

    public int GetCurrentPeriodNumber() => currentPeriodNumber;

    public abstract int GetDaysRemaining();
    public abstract int GetDaysUntilNextPeriod();
}

public class SemestralSchedule : ScheduleStructure
{
    private DateTime[][] pairs;
    private DateTime currentDate;

    public SemestralSchedule(DateTime currentDate, DateTime sem1Start, DateTime sem1End, DateTime sem2Start, DateTime sem2End, int currentPeriodNumber)
        : base(currentPeriodNumber)
    {
        this.currentDate = currentDate;
        pairs = new DateTime[2][];
        pairs[0] = new DateTime[] { sem1Start, sem1End };
        pairs[1] = new DateTime[] { sem2Start, sem2End };
    }

    public override int GetDaysRemaining()
    {
        int periodIndex = GetCurrentPeriodNumber() - 1;
        return (int)(pairs[periodIndex][1] - currentDate).TotalDays;
    }

    public override int GetDaysUntilNextPeriod()
    {
        int periodIndex = GetCurrentPeriodNumber() % 2; // Cycle between 0 and 1
        DateTime nextPeriodStart = pairs[periodIndex][0];
        if (periodIndex == 0) // If it's the end of the second semester, adjust for the next year
        {
            nextPeriodStart = new DateTime(pairs[1][1].Year + 1, nextPeriodStart.Month, nextPeriodStart.Day);
        }
        return (int)(nextPeriodStart - currentDate).TotalDays;
    }
}

public class SchoolYearSchedule : ScheduleStructure
{
    private DateTime start;
    private DateTime end;
    private DateTime currentDate;

    public SchoolYearSchedule(DateTime currentDate, DateTime start, DateTime end)
        : base(1) // School year schedule does not use period numbers, so default to 1
    {
        this.start = start;
        this.end = end;
        this.currentDate = currentDate;
    }

    public override int GetDaysRemaining()
    {
        return (int)(end - currentDate).TotalDays;
    }

    public override int GetDaysUntilNextPeriod()
    {
        DateTime nextStart = new DateTime(end.Year + 1, start.Month, start.Day);
        return (int)(nextStart - currentDate).TotalDays;
    }
}