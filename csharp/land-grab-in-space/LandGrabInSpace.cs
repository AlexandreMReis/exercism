using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

public struct Coord : IEqualityComparer<Coord>
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }

    public bool Equals(Coord c1, Coord c2)
    {
        return c1.X == c2.X && c1.Y == c2.Y;
    }

    public int GetHashCode([DisallowNull] Coord obj)
    {
        return obj.ToString().GetHashCode();
    }
}

public struct Plot : IEqualityComparer<Plot>
{
    public Plot (Coord firstV, Coord secondV, Coord thirdV, Coord fourthV)
    {
        FirstV = firstV;
        SecondV = secondV;
        ThirdV = thirdV;
        FourthV = fourthV;
        Staked = false;
    }
    public Coord FirstV { get; }
    public Coord SecondV { get; }
    public Coord ThirdV { get; }
    public Coord FourthV { get; }
    public bool Staked { get; set; }

    public bool Equals(Plot p1, Plot p2)
    {
        return p1.FirstV.Equals(p2.FirstV) && p1.SecondV.Equals(p2.SecondV) && p1.ThirdV.Equals(p2.ThirdV) && p1.FourthV.Equals(p2.FourthV);
    }

    public int GetHashCode([DisallowNull] Plot obj)
    {
        return obj.ToString().GetHashCode();
    }
}


public class ClaimsHandler
{
    private readonly List<Plot> plots = new();
    public void StakeClaim(Plot plot)
    {
        plot.Staked = true;
        this.plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return plots.Any(p => p.Equals(plot));
    }

    public bool IsLastClaim(Plot plot)
    {
        var lastPlot = this.plots.Last();

        return lastPlot.Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        throw new NotImplementedException("Please implement the ClaimsHandler.GetClaimWithLongestSide() method");
    }
}
