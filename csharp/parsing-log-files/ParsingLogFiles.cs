using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class LogParser
{
    
    public bool IsValidLine(string text)
    {
        string tag = text[..5];

        return tag switch
        {
            LogTags.TRC or LogTags.DBG or LogTags.INF or LogTags.WRN or LogTags.ERR or LogTags.FTL => true,
            _ => false,
        };
    }

    public string[] SplitLogLine(string text)
    {
        List<string> output = new();

        if (string.IsNullOrEmpty(text)) 
        {
            output.Add("");
            return output.ToArray();
        } 

        Regex regex = new("[<[^*=-]*>]*", RegexOptions.IgnoreCase);

        MatchCollection tagMatches = regex.Matches(text);

        int currentIndex = 0;

        foreach(Match tagMatch in tagMatches)
        {
            output.Add(text[currentIndex..tagMatch.Index]);

            currentIndex = tagMatch.Index + tagMatch.Length;
        }

        string lastMatch = text[currentIndex..];

        if(!string.IsNullOrEmpty(lastMatch)) output.Add(lastMatch);

        return output.ToArray();
    }

    public int CountQuotedPasswords(string lines)
    {
        if (string.IsNullOrEmpty(lines))
        {
            return 0;
        }

        Regex regex = new("\"[A-Za-z\\s]*password[A-Za-z\\s]*\"", RegexOptions.IgnoreCase);

        MatchCollection matches = regex.Matches(lines);

        return matches.Count;
    }

    public string RemoveEndOfLineText(string line)
    {
        if (string.IsNullOrEmpty(line))
        {
            return string.Empty;
        }

        Regex regex = new("end-of-line\\d*", RegexOptions.IgnoreCase);

        return regex.Replace(line, string.Empty);
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        if(lines == null || lines.Length == 0)
        {
            return Array.Empty<string>();
        }

        List<string> output = new();

        foreach(string line in lines)
        {
            Regex regex = new("password[0-9a-zA-Z]+", RegexOptions.IgnoreCase);

            Match match = regex.Match(line);
            string foundPassword = match.Value;
            if(string.IsNullOrEmpty(foundPassword)) foundPassword = "--------";

            output.Add($"{foundPassword}: {line}");
        }

        return output.ToArray();
    }
}

public class LogTags
{
    public const string TRC = "[TRC]";
    public const string DBG = "[DBG]";
    public const string INF = "[INF]";
    public const string WRN = "[WRN]";
    public const string ERR = "[ERR]";
    public const string FTL = "[FTL]";
}
