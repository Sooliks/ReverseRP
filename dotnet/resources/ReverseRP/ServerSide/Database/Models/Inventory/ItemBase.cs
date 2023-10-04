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
        NAPI.Object.CreateObject(ItemType.Hash, new Vector3(player.Position.X, player.Position.Y, player.Position.Z - 1.01f), new Vector3(), dimension: player.Dimension);
        NAPI.TextLabel.CreateTextLabel($"{ItemType.Name} {count} шт.",
            new Vector3(player.Position.X, player.Position.Y, player.Position.Z - 0.5f), 10.0f, 0.45f, 4,
            new Color(255, 255, 255));
        InventoryService.DroppedItems.Add(new DroppedItemModel(this, player.Position, player.Dimension));
    }
}