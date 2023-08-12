using GTANetworkAPI;

namespace ServerSide.Database.Models;

public class ItemBase
{
    public int Id { get; set; }
    public int Count { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int IdItem { get; set; }
    public int Hash { get; set; }
    public Character Character { get; set; } = null!;

    public virtual void DropItem(Player player)
    {
        NAPI.Object.CreateObject(Hash, player.Position, new Vector3());
    }

    public ItemBase(int count, string name, string description, int idItem, int hash = 0)
    {
        Count = count;
        Name = name;
        Description = description;
        IdItem = idItem;
        Hash = hash;
    }
}