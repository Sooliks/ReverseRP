using GTANetworkAPI;
using ServerSide.Extensions.VehicleExtensions;

namespace ServerSide.EventsHandlers.VehicleEvents;

public class EventsInfoVehicle : Script
{
    [RemoteProc("RPC::CEF::SERVER:GetFuelTankCapacity")]
    public string OnGetFuelTankCapacity(Player player)
    {
        if(!player.IsInVehicle)return null;
        var vehicleModel = player.Vehicle.GetVehicleModel();
        return NAPI.Util.ToJson(vehicleModel.VehicleType.FuelTankCapacity - vehicleModel.FuelTank);
    }
}