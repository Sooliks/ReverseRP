using GTANetworkAPI;

namespace ServerSide.EventsHandlers.VehicleEvents;

public class EventsManagementVehicle : Script
{
    [RemoteEvent("CLIENT::SERVER:PRESS_CTRL_IN_VEHICLE")]
    public void OnPressCtrlInVehicle(Player player)
    {
        var vehicle = player.Vehicle;
        if(vehicle == null)return;
        player.Vehicle.EngineStatus = !vehicle.EngineStatus;
    }
}