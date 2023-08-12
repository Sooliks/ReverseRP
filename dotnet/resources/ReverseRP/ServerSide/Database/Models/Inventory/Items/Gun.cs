using ServerSide.Database.Models;

namespace ServerSide.Inventory.Items;

public class Gun : ItemBase
{
    public Gun(int count, string name,string description,int idItem, int hash): base(count, name, description, idItem, hash)
    {
        
    }
    public void Use()
    {
        //достаем ган
    }
    public override void DropItem()
    {
        //дропаем ган если умираем с ним в руках
        base.DropItem();
    }
}