using ServerSide.Database.Models;

namespace ServerSide.Inventory.Items;

public class Food : ItemBase
{
    public Food(int count, string name,string description,int idItem): base(count, name, description, idItem)
    {
        
    }
    public void Use()
    {
        //хаваем
    }
}