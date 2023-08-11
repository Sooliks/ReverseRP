namespace ServerSide.Database.Models;

public class ItemBase
{
    public int Id { get; set; }
    public int Count { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int IdItem { get; set; }

    public virtual void DropItem()
    {
        
    }

    public ItemBase(int count, string name, string description, int idItem)
    {
        Count = count;
        Name = name;
        Description = description;
        IdItem = idItem;
    }
}