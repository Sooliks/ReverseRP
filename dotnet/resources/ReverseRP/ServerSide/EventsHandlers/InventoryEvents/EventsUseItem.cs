using GTANetworkAPI;

namespace ServerSide.EventsHandlers.Inventory;

public class EventsUseItem
{
    [RemoteEvent("CEF::SERVER:USE_ITEM")]
    public void OnUseItem(Player player)
    {
        
    }
}