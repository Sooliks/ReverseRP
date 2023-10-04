using System.Collections.Generic;
using GTANetworkAPI;
using ServerSide.Database.Models;

namespace ServerSide.Services.InventoryService;

public class ItemService
{
    public static List<DroppedItemModel> DroppedItems = new List<DroppedItemModel>()
    {
        
    };

    public static void SpawnItem(ItemBase itemBase, Vector3 position, uint dimension, int count)
    {
        NAPI.Object.CreateObject(itemBase.ItemType.Hash, new Vector3(position.X, position.Y, position.Z - 1.01f), new Vector3(), dimension: dimension);
        NAPI.TextLabel.CreateTextLabel($"{itemBase.ItemType.Name} {count} шт.",
            new Vector3(position.X, position.Y, position.Z - 0.5f), 10.0f, 0.45f, 4,
            new Color(255, 255, 255));
        ItemService.DroppedItems.Add(new DroppedItemModel(itemBase, position, dimension));
    }
}