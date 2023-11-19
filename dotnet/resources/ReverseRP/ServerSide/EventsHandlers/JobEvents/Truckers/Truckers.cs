using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Database.Models.Businesses;

namespace ServerSide.EventsHandlers.JobEvents.Truckers;

public class Truckers : Script
{
    [RemoteProc("RPC::CEF::SERVER:GET_ORDERS_LIST")]
    public string OnGetOrdersList(Player player)
    {
        return NAPI.Util.ToJson(GeneralHandler.GetRecords<OrderBusiness>());
    }
}