namespace ServerSide.Inventory;

public class ItemBase
{
    public int Id { get; set; }
    public int Count { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public void DropItem()
    {
        
    }
}