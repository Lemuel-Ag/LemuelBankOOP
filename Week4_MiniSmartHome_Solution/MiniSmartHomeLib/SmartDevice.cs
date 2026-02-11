using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSmartHomeLib
{
    public abstract class SmartDevice
    {
        private string name;

        public string DeviceId { get; }
        public string Name => name;
        public PowerModule Power { get; }

        protected SmartDevice(string deviceId, string name)
        {
            if (string.IsNullOrWhiteSpace(deviceId))
                throw new ArgumentException("The deviceId cannot be null or blank!");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The name cannot be null or blank!");

            DeviceId = deviceId;
            name = name;

            // Composition happens here
            Power = new PowerModule();
        }

        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("The name cannot be null or blank!");

            name = newName;
        }

        public virtual void SetOnline(bool online)
        {
            Power.SetOnline(online);
        }

        public virtual void TurnOn()
        {
            Power.TurnOn();
        }

        public virtual void TurnOff()
        {
            Power.TurnOff();
        }

        public abstract string GetStatus();
    }
    
}
