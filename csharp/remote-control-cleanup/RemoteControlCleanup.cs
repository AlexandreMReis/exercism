public class RemoteControlCar
{
    #region Properties
    public string CurrentSponsor { get; protected set; }
    #endregion
    
    #region Fields
    public Speed currentSpeed { get; private set; }
    public ITelemetry Telemetry { get; private set; }
    #endregion

    #region Constructors
    public RemoteControlCar()
    {
        this.Telemetry = new RemoteControlCarTelemetry(this);
    }
    #endregion

    #region Enums
    public enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }
    #endregion

    #region Methods
    public string GetSpeed()
    {
        return this.Telemetry.GetSpeed();
    }

    private void SetSpeed(Speed speed)
    {
        this.currentSpeed = speed;
    }

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;
    }
    #endregion

    #region Structs
    public struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }
    #endregion

    #region Interfaces
    public interface ITelemetry
    {
        void Calibrate();
        bool SelfTest();
        void ShowSponsor(string sponsorName);
        void SetSpeed(decimal amount, string unitsString);
        string GetSpeed();
    }
    #endregion

    #region Classes
    public class RemoteControlCarTelemetry : ITelemetry
    {
        private RemoteControlCar parent;

        public RemoteControlCarTelemetry(RemoteControlCar parent)
        {
            this.parent = parent;
        }

        public void Calibrate()
        {

        }

        public bool SelfTest()
        {
            return true;
        }

        public void ShowSponsor(string sponsorName)
        {
            this.parent.CurrentSponsor = sponsorName;
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            this.parent.SetSpeed(new Speed(amount, speedUnits));
        }

        public string GetSpeed()
        {
            return this.parent.currentSpeed.ToString();
        }
    }
    #endregion
}



