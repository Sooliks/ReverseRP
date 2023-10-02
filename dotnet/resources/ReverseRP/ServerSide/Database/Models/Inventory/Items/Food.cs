using ServerSide.Database.Models;

namespace ServerSide.Inventory.Items;

public class Food : ItemBase
{
    public int CountSatiety { get; set; }
    public Food(int count, Item item, int countSatiety): base(count, item)
    {
        CountSatiety = countSatiety;
    }

    public Food()
    {
        
    }
    public void Use()
    {
        //хаваем
    }
}