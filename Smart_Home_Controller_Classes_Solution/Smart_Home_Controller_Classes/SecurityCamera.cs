using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeLib;
public class SecurityCamera : SmartDevice
    {
        private bool isRecording;  // True/False
        private int storageUsedMB;

        public int StorageCapacityMB { get; }  //Read only

        public SecurityCamera(string deviceId, string name, int storageCapacityMB)
            : base(deviceId, name)
        {
            if (storageCapacityMB <= 0)
                throw new ArgumentException("The storage capacity must be greater than zero!", nameof(storageCapacityMB));

            StorageCapacityMB = storageCapacityMB;
            storageUsedMB = 0;                          //Defaults
            isRecording = false;
        }

        public void StartRecording()
        {
            if (!IsOnline)
                throw new InvalidOperationException("The camera must be online to start recording!");

            if (!IsPoweredOn)
                throw new InvalidOperationException("The camera must be powered on to start recording!");

            if (storageUsedMB >= StorageCapacityMB)
                throw new InvalidOperationException("There is no storage available to start recording!");

            isRecording = true;
        }

        public void StopRecording()
        {
            isRecording = false;
        }

        public void SimulateRecording(int minutes)
        {
            if (!isRecording)
                throw new InvalidOperationException("Camera is not recording.");

            if (minutes <= 0)
                throw new ArgumentException("Minutes must be greater than zero.", nameof(minutes));

            int additionalStorage = minutes * 5;

            if (storageUsedMB + additionalStorage > StorageCapacityMB)
                throw new InvalidOperationException("Recording would exceed storage capacity.");

            storageUsedMB += additionalStorage;
        }


        public override void ApplyMode(string mode)
        {
            if (mode == "Night")
            {
                StartRecording();
            }
        }

        public override string GetStatus()
        {
            string onlineStatus = IsOnline ? "Online" : "Offline";
            string powerStatus = IsPoweredOn ? "On" : "Off";
            string recordingStatus = isRecording ? "Recording" : "NotRecording";

            return $"Camera '{Name}' ({onlineStatus}, {powerStatus}) --> {recordingStatus}, Storage: {storageUsedMB}/{StorageCapacityMB} MB";
        }
    }


