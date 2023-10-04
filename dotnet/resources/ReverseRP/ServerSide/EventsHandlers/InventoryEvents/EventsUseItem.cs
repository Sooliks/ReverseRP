using System.Linq;
using GTANetworkAPI;
using ServerSide.Database.Models;
using ServerSide.Extensions;
using ServerSide.Services.InventoryService;

namespace ServerSide.EventsHandlers.Inventory;

public class EventsUseItem : Script
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

    [RemoteEvent("CLIENT::SERVER:ON_PICKUP_ITEM")]
    public void OnPickupItem(Player player)
    {
        var itemBase = ItemService.GetClosestItemBase(player);
        if (itemBase != null)
        {
            ItemService.DestroyItem(itemBase);
            player.AddItem(itemBase.ItemType, itemBase.Count);
        }
    }
}