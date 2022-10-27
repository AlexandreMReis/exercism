using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Plot (Coord firstV, Coord secondV, Coord thirdV, Coord fourthV)
    {
        FirstV = firstV;
        SecondV = secondV;
        ThirdV = thirdV;
        FourthV = fourthV;
        LongestSide = GetLongestSide(FirstV, SecondV, ThirdV, FourthV);
    }
    public Coord FirstV { get; }
    public Coord SecondV { get; }
    public Coord ThirdV { get; }
    public Coord FourthV { get; }
    public double LongestSide { get; }

    private static double GetLongestSide(Coord firstV, Coord secondV, Coord thirdV, Coord fourthV)
    {
        var sides = new List<double>
        {
            GetDistanceBetweenCoords(firstV, secondV),
            GetDistanceBetweenCoords(secondV, thirdV),
            GetDistanceBetweenCoords(thirdV, fourthV),
            GetDistanceBetweenCoords(fourthV, firstV)
        };

        return sides.Max();
    }

    private static double GetDistanceBetweenCoords(Coord coordOne, Coord coordTwo)
    {
        return Math.Sqrt(Math.Pow(coordOne.X - coordTwo.X, 2) + Math.Pow(coordOne.Y - coordTwo.Y, 2));
    }
}

public class ClaimsHandler
{
    private readonly List<Plot> plots = new();
    public void StakeClaim(Plot plot)
    {
        this.plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot) => plots.Contains(plot);

    public bool IsLastClaim(Plot plot) => plots.Last().Equals(plot);

    public Plot GetClaimWithLongestSide() => this.plots.OrderByDescending(p => p.LongestSide).FirstOrDefault();
}
