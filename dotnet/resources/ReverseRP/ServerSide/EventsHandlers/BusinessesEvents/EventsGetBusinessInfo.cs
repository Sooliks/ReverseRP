using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Database.Models;

namespace ServerSide.EventsHandlers.BusinessesEvents;

public class EventsGetBusinessInfo : Script
{
    [RemoteProc("RPC::CEF::SERVER:GetProductsMarket")]
    public string OnGetProductsMarket(int businessId)
    {
        if (BusinessHandler.GetBusinessById(businessId) is Market market)
        {
            return NAPI.Util.ToJson(market.Items);
        }

        return null;
    }
    [RemoteProc("RPC::CEF::SERVER:GetStatisticsBusiness")]
    public string OnGetStatisticsBusiness(int businessId)
    {
        return NAPI.Util.ToJson(StatisticBusinessHandler.GetCountVisitorsAllDays(BusinessHandler.GetBusinessById(businessId)));
    }
}