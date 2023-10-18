namespace ServerSide.Database.Models;

public class ItemBusiness
{
    public int ItemId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }

    public ItemBusiness(int itemId, int count, int price)
    {
        ItemId = itemId;
        Count = count;
        Price = price;
    }
}