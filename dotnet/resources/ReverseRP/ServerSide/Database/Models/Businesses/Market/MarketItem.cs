namespace ServerSide.Database.Models;

public class MarketItem : ItemBusiness
{
    public int IdItem { get; set; }
    public MarketItem(int idItem, int count, int price)
    {
        IdItem = idItem;
        Count = count;
        Price = price;
    }
}