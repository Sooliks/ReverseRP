using GTANetworkAPI;

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
        NAPI.Object.CreateObject(ItemType.Hash, player.Position, new Vector3(), dimension: player.Dimension);
    }
}