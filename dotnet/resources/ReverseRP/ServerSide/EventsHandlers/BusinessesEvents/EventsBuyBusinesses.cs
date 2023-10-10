using GTANetworkAPI;
using NLog.Config;
using ServerSide.Database.Handlers;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.BusinessesEvents;

public class EventsBuyBusinesses
{
    [RemoteEvent("CEF::SERVER:ON_BUY_BUSINESS")]
    public void OnBuyBusiness(Player player, int businessId)
    {
        var business = BusinessHandler.GetBusinessById(businessId);
        if (player.MinusMoney(business.GosPrice))
        {
            if(business.OwnerCharacter==null)return;
            BusinessHandler.SetOwnerCharacterBusiness(player.GetCharacter(), businessId);
        }
    }
}