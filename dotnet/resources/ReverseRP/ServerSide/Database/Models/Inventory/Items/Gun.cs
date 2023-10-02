using GTANetworkAPI;
using ServerSide.Database.Models;

namespace ServerSide.Inventory.Items;

public class Gun : ItemBase
{
    public Gun(int count, Item item): base(count,item)
    {
        
    }

    public Gun()
    {
        
    }
    public void Use()
    {
        //достаем ган
    }
    public override void DropItem(Player player)
    {
        //дропаем ган если умираем с ним в руках
        base.DropItem(player);
    }
}