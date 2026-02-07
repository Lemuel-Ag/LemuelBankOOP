using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeLib;

public class SmartLight : SmartDevice
{
    private int brightness;
    private string color;

    public SmartLight(string deviceId, string name)
    : base(deviceId, name)
    {
        brightness = 40;  
        color = "Red";  
    }

    public void SetBrightness(int value)
    {
        if (value < 0 || value > 100)
            throw new ArgumentException("The brightness must be between 0 and 100!", nameof(value));

        if (!IsPoweredOn)
            throw new InvalidOperationException("The light must be powered on to change brightness!");

        brightness = value;
    }

    public void SetColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            throw new ArgumentException("The color cannot be blank!", nameof(color));

        if (!IsPoweredOn)
            throw new InvalidOperationException("The light must be powered on to change color!");

        color = color.Trim();
    }

    public override void ApplyMode(string mode)
    {
        if (mode == "Night" && IsPoweredOn)
        {
            brightness = 10;
        }
    }

    public override string GetStatus()
    {
        string onlineStatus = IsOnline ? "Online" : "Offline";
        string powerStatus = IsPoweredOn ? "On" : "Off";

        return $"Light '{Name}' ({onlineStatus}, {powerStatus}) --> Brightness: {brightness}, Color: {color}";
    }
}

    

