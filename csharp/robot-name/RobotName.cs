using System;
using System.Collections.Generic;
using System.Linq;

public class Robot
{
    public Robot() => Name = GenerateUniqueName();

    public string Name { get; set; }

    private static string GenerateName()
    {
        Random rnd = new Random();
        string randomString = new string(Enumerable.Repeat("QWERTYUIOPASDFGHJKLZXCVBNM", 2).Select(s => s[rnd.Next(s.Length)]).ToArray());
        return $"{randomString}{rnd.Next(9)}{rnd.Next(9)}{rnd.Next(9)}";
    }

    private string GenerateUniqueName()
    {
        string robotName = GenerateName();
        while (RobotHelper.RobotNames.Contains(robotName))
        {
            robotName = GenerateName();
        }

        RobotHelper.RobotNames.Add(robotName);

        return robotName;
    }

    public void Reset() => Name = GenerateUniqueName();
}

public static class RobotHelper
{
    public static HashSet<string> RobotNames = new();
}