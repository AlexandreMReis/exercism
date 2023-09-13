using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length) throw new ArgumentException("The strands should have the same length");

        if(firstStrand.Equals(secondStrand)) return 0;

        int hDistance = 0;
        for (int i = 0; i< firstStrand.Length; i++)
        {
            hDistance += firstStrand[i] != secondStrand[i] ? 1 : 0;
        }

        return hDistance;
    }
}