using System;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Extensions;
using ServerSide.Services.InventoryService;

namespace ServerSide.Database.Models;

public class ItemBase
{
    public int Id { get; set; }
    public int Count { get; set; }
    public ItemType ItemType { get; set; }
    public Character? Character { get; set; } = new Character();
    public ItemBase(int count, ItemType item)
    {
        Count = count;
        ItemType = item;
    }

    public ItemBase()
    {
        
    }
    
    public virtual void DropItem(Player player, int count)
    {
        if (count > Count || count < 1)
        {
            return;
        }
        InventoryHandler.RemoveItem(player.GetCharacter(), this, count);
        ItemService.SpawnItem(this, player.Position, player.Dimension, count);
    }
}