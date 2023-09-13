using System;
using System.Collections.Generic;

public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    private readonly int _mask;
    public Allergies(int mask) => _mask = mask;

    public bool IsAllergicTo(Allergen allergen)
    {
        if ((int)allergen == 0)
        {
            return _mask % 2 == 1;
        }

        var allergenNumber = Math.Pow(2, (int)allergen);

        return ((int)allergenNumber & _mask) == allergenNumber;
    }

    public Allergen[] List()
    {
        List<Allergen> output = new List<Allergen>();
        foreach(Allergen allergen in Enum.GetValues(typeof(Allergen)))
        {
            if (IsAllergicTo(allergen)) output.Add(allergen);
        }

        return output.ToArray();
    }
}