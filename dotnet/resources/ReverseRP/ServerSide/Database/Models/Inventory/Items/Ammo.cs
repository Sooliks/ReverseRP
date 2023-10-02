using ServerSide.Database.Models;
using ServerSide.Inventory.Enums;

namespace ServerSide.Inventory.Items;

public class Ammo : ItemBase
{
    public TypeAmmo TypeAmmo { get; set; }
    public Ammo(int count, Item item, TypeAmmo typeAmmo): base(count, item)
    {
        TypeAmmo = typeAmmo;
    }

    public Ammo()
    {
        
    }
}