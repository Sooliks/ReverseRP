using GTANetworkAPI;
using NLog.Config;
using ServerSide.Database.Handlers;
using ServerSide.Database.Handlers.BusinessesHandlers;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.BusinessesEvents;

public class EventsBuyBusinesses : Script
{
    [RemoteProc("RPC::CEF::SERVER:ON_BUY_BUSINESS")]
    public string OnBuyBusiness(Player player, int businessId)
    {
        var business = BusinessHandler.GetBusinessById(businessId);
        if (player.MinusMoney(business.GosPrice))
        {
            if(business.OwnerCharacterId!=0)return NAPI.Util.ToJson(false);
            BusinessHandler.SetOwnerCharacterBusiness(player.GetCharacter(), businessId);
            return NAPI.Util.ToJson(true);
        }
        return NAPI.Util.ToJson(false);
    }
}