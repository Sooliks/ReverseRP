namespace ServerSide.Database.Models;

public class ItemType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public uint Hash { get; set; }
    public int IdItem { get; set; }

    public ItemType()
    {
        
    }
    public ItemType(string name, string description, uint hash, int idItem)
    {
        Name = name;
        Description = description;
        Hash = hash;
        IdItem = idItem;
    }
}