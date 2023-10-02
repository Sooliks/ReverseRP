using System.Collections.Generic;
using System.Linq;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json;
using ServerSide.Database.Handlers;

namespace ServerSide.Database.Models;


public class Character
{
    public int Id { get; set; }
    public Account? Account { get; set; }
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
    public List<ItemBase>? Inventory { get; set; }

    public byte CountSatiety
    {
        get
        {
            return CountSatiety;
        }
        set
        {
            CountSatiety = value;
            using Context db = new Context();
            var character = db.Character.FirstOrDefault(c => c.Id == this.Id);
            character.CountSatiety = value;
            db.Character.Update(character);
            db.SaveChanges();
        }
    }

    public Character()
    {
        
    }

    public Character(Account account,string firstName, string lastName, byte birth, string origin,
        string headOverlaysJson, string headOverlaysColorsJson, string headBlendDataJson,
        string faceFeaturesJson, byte eyeColor, byte hairColor, int hairType, bool gender)
    {
        Account = account;
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
        Inventory = new List<ItemBase>();
        CountSatiety = 100;
    }
    
    public static List<ItemBase> GetInventory(Character character) => InventoryHandler.GetInventory(character);
    public static void AddItem(Character character, ItemBase item) => InventoryHandler.AddItem(character, item);
    public static void RemoveItem(Character character, ItemBase item) => InventoryHandler.RemoveItem(character, item);
    
}