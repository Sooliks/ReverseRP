namespace ServerSide.Database.Models;

public class BusinessBase
{
    public int Id { get; set; }
    public Character? OwnerCharacter { get; set; }
    public int Bank { get; set; }

    public BusinessBase(int bank)
    {
        Bank = bank;
    }
    
}