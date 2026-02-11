using System;
using MiniSmartHomeLib;

namespace MiniSmartHomeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var group = new DeviceGroups();

            var light = new SmartLight("001", "Living Room Light");

            group.AddDevice(light);

            // Intentional error
            try
            {
                light.TurnOn();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            // The proper usage
            light.Rename("Main Living Room Light");
            light.SetOnline(true);
            light.TurnOn();
            light.SetBrightness(75);

            Console.WriteLine("\n--- Device Status ---");
            group.PrintStatuses();

            Console.WriteLine("\n--- Turning Off All Devices ---");
            group.TurnOffAll();

            group.PrintStatuses();
        }
    }
}