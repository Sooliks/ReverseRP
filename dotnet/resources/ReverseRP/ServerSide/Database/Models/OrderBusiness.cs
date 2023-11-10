namespace ServerSide.Database.Models;

public class OrderBusiness
{
    public int Id { get; set; }
    public BusinessBase? BusinessBase { get; set; }
    public int ItemId { get; set; }
    public int Count { get; set; }
    public bool Active { get; set; }
    public OrderBusiness(int itemId, int count, bool active)
    {
        ItemId = itemId;
        Count = count;
        Active = active;
    }
    public OrderBusiness()
    {
        
    }
}