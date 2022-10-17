using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        long output;
        try 
        { 
            output = checked(@base * multiplier);
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }
        return output.ToString();
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float output;
        output = @base * multiplier;
        if (float.IsInfinity(output))
        {
            return "*** Too Big ***";
        }
        return output.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        decimal output;
        try
        {
            output = salaryBase * multiplier;
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }
        return output.ToString();
    }
}
