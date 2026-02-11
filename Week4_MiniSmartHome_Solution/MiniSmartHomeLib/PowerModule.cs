using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSmartHomeLib
{
    public class PowerModule
    {
        private bool isOnline;
        private bool isPoweredOn;

        public bool IsOnline => isOnline;
        public bool IsPoweredOn => isPoweredOn;

        public void SetOnline(bool online)
        {
            isOnline = online;

            // If device goes offline, power must shut off
            if (!isOnline)
            {
                isPoweredOn = false;
            }
        }

        public void TurnOn()
        {
            if (!isOnline)
            {
                throw new InvalidOperationException("Cannot turn on device while offline!");
            }

            isPoweredOn = true;
        }

        public void TurnOff()
        {
            isPoweredOn = false;
        }
    }
}
