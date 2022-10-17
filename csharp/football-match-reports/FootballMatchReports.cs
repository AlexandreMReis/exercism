using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        return shirtNum switch
        {
            1 => "goalie",
            2 => "left back",
            3 or 4 => "center back",
            5 => "right back",
            6 or 7 or 8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public static string AnalyzeOffField(object report)
    {
        if(report is int)
        {
            return $"There are {report} supporters at the match.";
        }
        else if(report is string)
        {
            return (string) report;
        }
        else if (report is Foul)
        {
            var foul = (Foul)report;
            return foul.GetDescription();
        }
        else if (report is Injury)
        {
            var injury = (Injury)report;
            return $"Oh no! {injury.GetDescription()} Medics are on the field.";
        }
        else if (report is Incident)
        {
            var incident = (Incident)report;
            return incident.GetDescription();
        }
        else if (report is Manager)
        {
            var manager = (Manager) report;
            return manager.Club != null ? $"{manager.Name} ({manager.Club})" : $"{manager.Name}";
        }

        throw new ArgumentException();
    }
}
