using ServerSide.Database.Models;

namespace ServerSide.Inventory.Items;

public class Food : ItemBase
{
    public Food(int count, string name,string description,int idItem, int hash): base(count, name, description, idItem,hash)
    {
        
    }
    public void Use()
    {
        //хаваем
    }
}