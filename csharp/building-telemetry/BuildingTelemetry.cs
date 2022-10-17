using System.Linq;

public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors)
    {
        foreach (string sponsor in sponsors)
        {
            this.sponsors = this.sponsors.Append(sponsor).ToArray();
        }
    }

    public string DisplaySponsor(int sponsorNum)
    {
        return this.sponsors[sponsorNum];
    }

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (serialNum < this.latestSerialNum)
        {
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            serialNum = this.latestSerialNum;
            return false;
        }

        this.latestSerialNum = serialNum;
        batteryPercentage = this.batteryPercentage;
        distanceDrivenInMeters = this.distanceDrivenInMeters;
        return true;

    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        var success = this.car.GetTelemetryData(ref serialNum, out int batteryPercentage, out int distanceDrivenInMeters);
        if(!success || distanceDrivenInMeters == 0)
        {
            return "no data";
        }

        return $"usage-per-meter={(100 - batteryPercentage) / distanceDrivenInMeters}";
    }
}
