using GTANetworkAPI;
using ServerSide.Database.Models;

namespace ServerSide.Services.InventoryService;

public class DroppedItemModel
{
    public ItemBase ItemBase { get; set; }
    public Vector3 Position { get; set; }
    public uint Dimension { get; set; }

    public DroppedItemModel(ItemBase itemBase, Vector3 position, uint dimension)
    {
        ItemBase = itemBase;
        Position = position;
        Dimension = dimension;
    }
}