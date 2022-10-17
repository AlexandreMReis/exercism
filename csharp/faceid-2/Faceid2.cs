using System;
using System.Collections.Generic;

public class FacialFeatures : IEquatable<FacialFeatures>
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public bool Equals(FacialFeatures other) => this.EyeColor == other.EyeColor && this.PhiltrumWidth == other.PhiltrumWidth;
}

public class Identity : IEquatable<Identity>
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public bool Equals(Identity other) => this.Email.Equals(other.Email) && this.FacialFeatures.Equals(other.FacialFeatures);
}

public class Authenticator
{
    private readonly List<Identity> _identities = new List<Identity>();
    private readonly Identity _admin = new("admin@exerc.ism", new FacialFeatures("green", 0.9m));

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Equals(_admin);

    public bool Register(Identity identity)
    {
        if (IsRegistered(identity)) { 
            return false;
        }
        this._identities.Add(identity);
        return true;
    }

    public bool IsRegistered(Identity identity) => this._identities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => ReferenceEquals(identityA,identityB);
}
