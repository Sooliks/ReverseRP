using ServerSide.Database.Models;
using ServerSide.Inventory.Enums;

namespace ServerSide.Inventory.Items;

public class Ammo : ItemBase
{
    public TypeAmmo TypeAmmo { get; set; }
    public Ammo(int count, string name,string description,int idItem, TypeAmmo typeAmmo, int hash): base(count, name, description, idItem,hash)
    {
        TypeAmmo = typeAmmo;
    }
}