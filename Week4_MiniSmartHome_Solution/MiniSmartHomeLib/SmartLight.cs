using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSmartHomeLib
{
    public class SmartLight : SmartDevice
    {
            private int brightness; // 0–100

            public SmartLight(string deviceId, string name)
                : base(deviceId, name)
            {
                brightness = 0;
            }

            public void SetBrightness(int value)
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Brightness must be between 0 and 100.");

                if (!Power.IsPoweredOn)
                    throw new InvalidOperationException("Cannot set brightness while device is powered off.");

                brightness = value;
            }

            public override string GetStatus()
            {
                return $"ID: {DeviceId}\n" +
                       $"Name: {Name}\n" +
                       $"Online: {Power.IsOnline}\n" +
                       $"Powered On: {Power.IsPoweredOn}\n" +
                       $"Brightness: {brightness}\n";
            }
        }
    
}
