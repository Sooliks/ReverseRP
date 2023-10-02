using GTANetworkAPI;

namespace ServerSide.Database.Models;

public class ItemBase
{
    public int Id { get; set; }
    public int Count { get; set; }
    public Item Item { get; set; }
    public Character? Character { get; set; } = new Character();
    public ItemBase(int count, Item item)
    {
        Count = count;
        Item = item;
    }

    public ItemBase()
    {
        
    }
    
    public virtual void DropItem(Player player)
    {
        NAPI.Object.CreateObject(Item.Hash, player.Position, new Vector3(), dimension: player.Dimension);
    }
}