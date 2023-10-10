namespace ServerSide.Database.Models;

public class MarketItem
{
    public int IdItem { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }

    public MarketItem(int idItem, int count, int price)
    {
        IdItem = idItem;
        Count = count;
        Price = price;
    }
}