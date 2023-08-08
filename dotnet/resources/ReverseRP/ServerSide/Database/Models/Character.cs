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
    public byte EyeColor { get; set; }
    public byte HairColor { get; set; }
    public int HairType { get; set; }
    public bool Gender { get; set; }
    public long Money { get; set; }
    public long MoneyBank { get; set; }
    public int Lvl { get; set; }

    public Character()
    {
        
    }

    public Character(int accountId,string firstName, string lastName, byte birth, string origin,
        string headOverlaysJson, string headOverlaysColorsJson, string headBlendDataJson,
        string faceFeaturesJson, byte eyeColor, byte hairColor, int hairType, bool gender)
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
        Money = 1000;
        MoneyBank = 0;
        Lvl = 0;
        HairColor = hairColor;
        EyeColor = eyeColor;
        HairType = hairType;
    }
    
}