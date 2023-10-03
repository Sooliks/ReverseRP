
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Extensions;


namespace ServerSide.EventsHandlers.MarketEvents;

public class EventsShopping : Script
{
    [RemoteEvent("CEF::SERVER:ON_BUY_ITEM")]
    public void OnBuyItem(Player player,int marketId, int idItem, int itemType)
    {
        switch (itemType)
        {
            case 1:
                if (player.MinusMoney(120))
                {
                    player.AddItem(ItemTypeHandler.GetItemByIdItem(idItem));
                }
                break;
        }
    }
}