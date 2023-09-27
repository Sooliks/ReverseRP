using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using ServerSide.Database.Models;
using ServerSide.Extensions;

namespace ServerSide.Database.Handlers;

public class CharacterHandler
{
    public static List<Character> GetCharactersByAccount(Account account)
    {
        using Context db = new Context();
        var _account = db.Account.SingleOrDefault(a => a.Id == account.Id);
        db.Entry(_account).Collection(c=>c.Characters).Load();
        return _account.Characters;
    }
    public static void AddNewCharacter(Account account,string firstName, string lastName,
        byte birth, string origin, string headOverlaysJson, string headOverlaysColorsJson,
        string headBlendDataJson, string faceFeaturesJson, byte eyeColor, byte hairColor,
        int hairType, bool gender)
    {
        using Context db = new Context();
        var _account = db.Account.Include(a => a.Characters).SingleOrDefault(a => a.Id == account.Id);

        var character = new Character(_account, firstName, lastName, birth, origin, headOverlaysJson,
            headOverlaysColorsJson, headBlendDataJson, faceFeaturesJson, eyeColor, hairColor, hairType, gender);
        _account.Characters.Add(character);
        db.SaveChanges();
    }
    public static Character GetLastCharacterByAccount(Account account)
    {
        using Context db = new Context();
        var characters = db.Character.Include(c=>c.Account).Where(c => c.Account.Id == account.Id).ToList();
        int maxId = -1;
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].Id > maxId)
            {
                maxId = characters[i].Id;
            }
        }
        var character = characters.SingleOrDefault(c=>c.Id == maxId);
        db.Entry(character).Collection(c=>c.Inventory).Load();
        return character;
    }
    public static bool IsAccountOwnerCharacter(Account account, int idCharacter)
    {
        using Context db = new Context();
        var character = db.Character.Include(c=>c.Account).FirstOrDefault(c => c.Id == idCharacter);
        if (character.Account.Id == account.Id)
        {
            return true;
        }

        return false;
    }
    public static Character GetCharacterById(int id)
    {
        using Context db = new Context();
        var character = db.Character.SingleOrDefault(c => c.Id == id);
        db.Entry(character).Collection(c=>c.Inventory).Load();
        return character;
    }
    public static bool MinusMoney(Player player, int countMoney)
    {
        using Context db = new Context();
        var character = db.Character.SingleOrDefault(c => c.Id == player.GetCharacter().Id);
        if (character.Money > countMoney)
        {
            character.Money -= countMoney;
            db.Character.Update(character);
            db.SaveChanges();
            return true;
        }
        return false;
    }
    public static void PlusMoney(Player player, int countMoney)
    {
        using Context db = new Context();
        var character = db.Character.SingleOrDefault(c => c.Id == player.GetCharacter().Id);
        character.Money += countMoney;
        db.Character.Update(character);
        db.SaveChanges();
    }
    public static bool MinusMoneyBank(Player player, int countMoney)
    {
        using Context db = new Context();
        var character = db.Character.SingleOrDefault(c => c.Id == player.GetCharacter().Id);
        if (character.MoneyBank > countMoney)
        {
            character.MoneyBank -= countMoney;
            db.Character.Update(character);
            db.SaveChanges();
            return true;
        }
        return false;
    }
    public static void PlusMoneyBank(Player player, int countMoney)
    {
        using Context db = new Context();
        var character = db.Character.SingleOrDefault(c => c.Id == player.GetCharacter().Id);
        character.MoneyBank += countMoney;
        db.Character.Update(character);
        db.SaveChanges();
    }
}