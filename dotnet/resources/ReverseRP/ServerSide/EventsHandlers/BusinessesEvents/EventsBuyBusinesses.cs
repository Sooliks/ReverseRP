using GTANetworkAPI;
using NLog.Config;
using ServerSide.Database.Handlers;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.BusinessesEvents;

public class EventsBuyBusinesses : Script
{
    [RemoteProc("RPC::CEF::SERVER:ON_BUY_BUSINESS")]
    public bool OnBuyBusiness(Player player, int businessId)
    {
        var business = BusinessHandler.GetBusinessById(businessId);
        if (player.MinusMoney(business.GosPrice))
        {
            if(business.OwnerCharacterId!=0)return false;
            BusinessHandler.SetOwnerCharacterBusiness(player.GetCharacter(), businessId);
            return true;
        }

        return false;
    }
}