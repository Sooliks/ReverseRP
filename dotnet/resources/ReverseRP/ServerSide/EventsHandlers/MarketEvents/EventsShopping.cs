using GTANetworkAPI;

namespace ServerSide.EventsHandlers.MarketEvents;

public class EventsShopping : Script
{
    [RemoteEvent("CEF::SERVER:ON_BUY_ITEM")]
    public void OnBuyItem(int marketId)
    {
        
    }
}