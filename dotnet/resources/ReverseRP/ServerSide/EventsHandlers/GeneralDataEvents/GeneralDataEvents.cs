using GTANetworkAPI;
using ServerSide.Database.Handlers;

namespace ServerSide.EventsHandlers.GeneralDataEvents;

public class GeneralDataEvents : Script
{
    [RemoteProc("RPC::CEF::SERVER:GetVehiclesTypes")]
    public string OnGetVehiclesTypes(Player player)
    {
        return NAPI.Util.ToJson(VehicleTypeHandler.GetVehicleTypes());
    }
}