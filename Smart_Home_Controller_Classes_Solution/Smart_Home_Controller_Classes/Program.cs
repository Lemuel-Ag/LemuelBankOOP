using SmartHomeLib;
using SmartHomeLib;

var hub = new SmartHomeHub();

// You will add your devices here once you implement them.
// Example flow you should be able to run by the end:
// - create devices
// - SetOnline(true)
// - TurnOn()
// - ApplyModeToAll("Night")
// - PrintAllStatuses()

Console.WriteLine("SmartHomeConsole starting...");
Console.WriteLine("Add device creation and hub actions once classes are implemented.");

var livingRoomLight = new SmartLight("light-1", "Living Room Light");
var hallwayThermostat = new SmartThermostat("thermo-1", "Hallway Thermostat");
var frontDoorCamera = new SecurityCamera("cam-1", "Front Door Camera", 500);

livingRoomLight.SetOnline(true);
hallwayThermostat.SetOnline(true);              // All Devices online
frontDoorCamera.SetOnline(true);

livingRoomLight.TurnOn();
hallwayThermostat.TurnOn();                     // All Devices turned on
frontDoorCamera.TurnOn();

hub.AddDevice(livingRoomLight);
hub.AddDevice(hallwayThermostat);               // All Devices added to the Hub
hub.AddDevice(frontDoorCamera);

hub.ApplyModeToAll("Night");

hub.PrintAllStatuses();
