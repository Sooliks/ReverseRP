
using ServerSide.Database.Models;

namespace ServerSide.Inventory.Items;

public class Gun : ItemType
{
    public Gun(string name, string description, uint hash, int idItem): base(name, description, hash, idItem)
    {
        
    }

    public Gun()
    {
        
    }
    public void Use()
    {
        //достаем ган
    }
}