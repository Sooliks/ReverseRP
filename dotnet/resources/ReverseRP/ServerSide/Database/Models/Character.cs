namespace ServerSide.Database.Models;

public class Character
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte Birth { get; set; }
    public string Origin { get; set; }
    public string HeadOverlaysJson { get; set; }
    public string HeadOverlaysColorsJson { get; set; }
    public string HeadBlendDataJson { get; set; }
    public string FaceFeaturesJson { get; set; }
    public bool Gender { get; set; }

    public Character()
    {
        
    }

    public Character(int accountId,string firstName, string lastName, byte birth, string origin, string headOverlaysJson, string headOverlaysColorsJson, string headBlendDataJson, string faceFeaturesJson, bool gender)
    {
        AccountId = accountId;
        FirstName = firstName;
        LastName = lastName;
        Birth = birth;
        Origin = origin;
        HeadOverlaysJson = headOverlaysJson;
        HeadOverlaysColorsJson = headOverlaysColorsJson;
        HeadBlendDataJson = headBlendDataJson;
        FaceFeaturesJson = faceFeaturesJson;
        Gender = gender;
    }
    
}