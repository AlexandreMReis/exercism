using System;
using System.Text.RegularExpressions;

public static class LogTagEnum
{
    public const string Trace = "[TRC]";
    public const string Debug = "[DBG]";
    public const string Information = "[INF]";
    public const string Warning = "[WRN]";
    public const string Error = "[ERR]";
    public const string Fatal = "[FTL]";
}

public class LogParser
{
    private readonly string  regexExpression = @"^\[[A-Z]{3}\].*$";
    public bool IsValidLine(string text)
    {
        var first4letters = text[..5];
        return first4letters.StartsWith('[') && first4letters.EndsWith(']');
    }

    public string[] SplitLogLine(string text)
    {
        throw new NotImplementedException($"Please implement the LogParser.SplitLogLine() method");
    }

    public int CountQuotedPasswords(string lines)
    {
        throw new NotImplementedException($"Please implement the LogParser.CountQuotedPasswords() method");
    }

    public string RemoveEndOfLineText(string line)
    {
        throw new NotImplementedException($"Please implement the LogParser.RemoveEndOfLineText() method");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        throw new NotImplementedException($"Please implement the LogParser.ListLinesWithPasswords() method");
    }
}
