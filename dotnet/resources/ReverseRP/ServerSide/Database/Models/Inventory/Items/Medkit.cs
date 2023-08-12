using GTANetworkAPI;
using ServerSide.Database.Models;

namespace ServerSide.Inventory.Items;

public class Medkit : ItemBase
{
    public int CountHp { get; set; }
    public Medkit(int count, string name,string description,int idItem, int hash,int countHp): base(count, name, description, idItem,hash)
    {
        CountHp = countHp;
    }
    public void Use(Player player)
    {
        //хилимся
        player.Health += CountHp;
    }
}