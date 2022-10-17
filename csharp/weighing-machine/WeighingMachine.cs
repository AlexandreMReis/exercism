using System;
using System.ComponentModel.DataAnnotations;

class WeighingMachine
{
    private readonly int _precision;
    private double _weight;
    private double _tareAdjustment;

    public WeighingMachine(int precision)
    {
        this._precision = precision;
        this._tareAdjustment = 5.0;
    }

    public int Precision { get { return _precision; } }

    public double Weight 
    { 
        get 
        { 
            return _weight; 
        } 

        set 
        {
            if (value < 0) 
            {
                throw new ArgumentOutOfRangeException();
            }
            else { 
                _weight = value; 
            }
        } 
    }
    
    [Range(0, double.MaxValue)]
    public double TareAdjustment
    {
        get
        {
            return _tareAdjustment;
        }

        set
        {
            _tareAdjustment = value;
        }
    }

    public string DisplayWeight 
    { 
        get 
        {
            var output = this.Weight - this.TareAdjustment;
            return $"{string.Format("{0:0.000}", Math.Round(output, this.Precision))} kg"; 
        }
    }
}
