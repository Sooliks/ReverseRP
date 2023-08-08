using System.Collections.Generic;
using System.Linq;
using ServerSide.Database.Models;

namespace ServerSide.Database.Handlers;

public class CharacterHandler
{
    public static List<Character> GetCharactersByAccount(Account account)
    {
        using Context db = new Context();
        var characters = db.Character.Where(c => c.AccountId == account.Id).ToList();
        return characters;
    }

    public static void AddNewCharacter(Account account, string firstName, string lastName, byte birth, string origin, string headOverlaysJson, string headOverlaysColorsJson, string headBlendDataJson, string faceFeaturesJson, bool gender)
    {
        using Context db = new Context();
        var character = new Character(account.Id, firstName, lastName, birth, origin, headOverlaysJson,
            headOverlaysColorsJson, headBlendDataJson, faceFeaturesJson, gender);
        db.Character.Add(character);
        db.SaveChanges();
    }

    public static bool IsAccountOwnerCharacter(Account account, int idCharacter)
    {
        using Context db = new Context();
        var character = db.Character.FirstOrDefault(c => c.Id == idCharacter);
        if (character.AccountId == account.Id)
        {
            return true;
        }

        return false;
    }
}