using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeLib;

public class SmartThermostat : SmartDevice
{
    private int temperature;

    public SmartThermostat(string deviceId, string name)
    : base(deviceId, name)
    {
        temperature = 68;
    }

    public void SetTemperature(int temp)
    {
        if (temp < 50 || temp > 90)
            throw new ArgumentException("The temperature must be between 50 and 90!", nameof(temp));

        if (!IsPoweredOn)
            throw new InvalidOperationException("The thermostat must be powered on to set temperature!");

        temperature = temp;
    }

    public override void ApplyMode(string mode)
    {
        if (mode == "Night" && IsPoweredOn)
        {
            temperature = 65;
        }
    }

    public override string GetStatus()
    {
        string onlineStatus = IsOnline ? "Online" : "Offline";
        string powerStatus = IsPoweredOn ? "On" : "Off";

        return $"Thermostat '{Name}' ({onlineStatus}, {powerStatus}) --> Temperature: {temperature}°F";
    }
}
