using System;

public struct CurrencyAmount
{
    private readonly decimal amount;
    private readonly string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public override bool Equals(object obj) => this.currency == ((CurrencyAmount) obj).currency && this.amount == ((CurrencyAmount)obj).amount;

    public override int GetHashCode() => this.ToString().GetHashCode();

    public static bool operator ==(CurrencyAmount currAmountA, CurrencyAmount currAmountB) 
    {
        if (currAmountA.currency != currAmountB.currency) throw new ArgumentException();

        return currAmountA.Equals(currAmountB);
    }

    public static bool operator !=(CurrencyAmount currAmountA, CurrencyAmount currAmountB)
    {
        if (currAmountA.currency != currAmountB.currency) throw new ArgumentException();

        return !currAmountA.Equals(currAmountB);
    }

    public static bool operator >(CurrencyAmount currAmountA, CurrencyAmount currAmountB)
    {
        if (currAmountA.currency != currAmountB.currency) throw new ArgumentException();

        return currAmountA.amount > currAmountB.amount;
    }

    public static bool operator <(CurrencyAmount currAmountA, CurrencyAmount currAmountB)
    {
        if (currAmountA.currency != currAmountB.currency) throw new ArgumentException();

        return currAmountA.amount < currAmountB.amount;
    }

    public static CurrencyAmount operator +(CurrencyAmount currAmountA, CurrencyAmount currAmountB)
    {
        if (currAmountA.currency != currAmountB.currency) throw new ArgumentException();

        return new CurrencyAmount(currAmountA.amount + currAmountB.amount, currAmountA.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount currAmountA, CurrencyAmount currAmountB)
    {
        if (currAmountA.currency != currAmountB.currency) throw new ArgumentException();

        return new CurrencyAmount(currAmountA.amount - currAmountB.amount, currAmountA.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount currAmount, decimal value) => new CurrencyAmount(currAmount.amount * value, currAmount.currency);

    public static CurrencyAmount operator *(decimal value, CurrencyAmount currAmount) => new CurrencyAmount(currAmount.amount * value, currAmount.currency);

    public static CurrencyAmount operator /(CurrencyAmount currAmount, decimal value)
    {
        if (value <= 0) throw new ArgumentException();

        return new CurrencyAmount(currAmount.amount / value, currAmount.currency);
    }

    public static implicit operator decimal(CurrencyAmount currAmount) => currAmount.amount;

    public static implicit operator double(CurrencyAmount currAmount) => (double) currAmount.amount;
}
