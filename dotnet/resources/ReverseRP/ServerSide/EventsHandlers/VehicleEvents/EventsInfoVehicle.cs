using System.Linq;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Extensions;
using ServerSide.Extensions.VehicleExtensions;

namespace ServerSide.EventsHandlers.VehicleEvents;

public class EventsInfoVehicle : Script
{
    [RemoteProc("RPC::CEF::SERVER:GetFuelTankCapacity")]
    public string OnGetFuelTankCapacity(Player player)
    {
        if (!player.IsAuthorized()) return null;
        if(!player.IsInVehicle)return null;
        var vehicleModel = player.Vehicle.GetVehicleModel();
        return NAPI.Util.ToJson(vehicleModel.VehicleType.FuelTankCapacity - vehicleModel.FuelTank);
    }

    [RemoteProc("RPC::CEF::SERVER:GET_VEHICLES_CHARACTER")]
    public string OnGetVehiclesCharacter(Player player)
    {
        if (!player.IsAuthorized()) return null;
        return NAPI.Util.ToJson(CharacterHandler.GetVehicles(player.GetCharacter()).Select(v=>new
        {
            id = v.Id,
            name = $"{v.VehicleType.Mark} {v.VehicleType.Model}",
            registerNumber = v.RegisterNumber,
            vehicleTypeId = v.VehicleType.Id
        }));
    }
    
}