using System;
using System.Collections.Generic;

public static class ADNBase
{
    public const char A = 'A';
    public const char C = 'C';
    public const char G = 'G';
    public const char T = 'T';
}


public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> output = new Dictionary<char, int>()
        {
            {ADNBase.A, 0 },
            {ADNBase.C, 0 },
            {ADNBase.G, 0 },
            {ADNBase.T, 0 }
        };

        foreach(char c in sequence)
        {
            if (!output.ContainsKey(c)) throw new ArgumentException();

            output[c]++;
        }

        return output;
    }
}