using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public static class Tournament
{   
    public static void Tally(Stream inStream, Stream outStream)
    {
        Dictionary<string, List<int>> teamsResults = new Dictionary<string, List<int>>();

        var sb = new StringBuilder();
        var encoding = new UTF8Encoding();

        List<int> emptyResults = new List<int>() { 0, 0, 0 };

        string input = encoding.GetString(((MemoryStream) inStream).ToArray());

        List<string> splittedRows = input.Split("\n").ToList();
        foreach (var row in splittedRows)
        {
            var columns = row.Split(';');
            if(columns.Length != 3)
            {
                throw new ArgumentException();
            }
            var firstTeam = columns[0];
            var secondTeam = columns[1];
            var firstTeamResult = columns[2];
            teamsResults.TryAdd(firstTeam, emptyResults);
            if (firstTeamResult == "win")
            {

            }
            else if (firstTeamResult == "loss")
            {

            }
            else if(firstTeamResult == "draw")
            {

            }
            else
            {
                throw new ArgumentException();
            }
        }




        outStream = new MemoryStream(encoding.GetBytes(sb.ToString()));
    }
}
