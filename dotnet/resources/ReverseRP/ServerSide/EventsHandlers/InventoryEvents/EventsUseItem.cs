using System.Linq;
using GTANetworkAPI;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.Inventory;

public class EventsUseItem
{
    [RemoteEvent("CEF::SERVER:USE_ITEM")]
    public void OnUseItem(Player player, int idItem)
    {
        
    }
    [RemoteEvent("CEF::SERVER:DROP_ITEM")]
    public void OnDropItem(Player player, int idItem, int count)
    {
        var inventory = player.GetInventory();
        var item = inventory.FirstOrDefault(i => i.ItemType.IdItem == idItem);
        if (item != null)
        {
            item.DropItem(player,count);
        }
    }
}