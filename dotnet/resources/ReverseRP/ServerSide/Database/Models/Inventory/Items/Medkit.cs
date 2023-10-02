using GTANetworkAPI;
using ServerSide.Database.Models;

namespace ServerSide.Inventory.Items;

public class Medkit : ItemBase
{
    public int CountHp { get; set; }
    public Medkit(int count, Item item,int countHp): base(count,item)
    {
        CountHp = countHp;
    }

    public Medkit()
    {
        
    }
    public void Use(Player player)
    {
        //хилимся
        player.Health += CountHp;
    }
}