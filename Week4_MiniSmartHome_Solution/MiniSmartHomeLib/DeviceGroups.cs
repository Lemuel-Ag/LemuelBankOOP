using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSmartHomeLib
{
    public class DeviceGroups
    {
            private readonly List<SmartDevice> devices = new List<SmartDevice>();

            public void AddDevice(SmartDevice device)
            {
                if (device == null)
                    throw new ArgumentException("The device cannot be null!");

                if (devices.Any(d => d.DeviceId == device.DeviceId))
                    throw new InvalidOperationException("A device with this ID already exists!");

                devices.Add(device);
            }

            public void TurnOffAll()
            {
                foreach (var device in devices)
                {
                    device.TurnOff();
                }
            }

            public void PrintStatuses()
            {
                foreach (var device in devices)
                {
                    Console.WriteLine(device.GetStatus());
                }
            }
    }
}
