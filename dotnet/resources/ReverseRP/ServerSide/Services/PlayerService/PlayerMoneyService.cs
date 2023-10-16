
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Enums;
using ServerSide.Extensions;

namespace ServerSide.Services.PlayerService;

public class PlayerMoneyService
{
    public static bool MinusMoney(Player player, int countMoney)
    {
        var character = player.GetCharacter();
        if (CharacterHandler.MinusMoney(character, countMoney))
        {
            player.TriggerCefEvent("SERVER::CEF:UPDATE_HUD", new {money = character.Money, moneyBank = character.MoneyBank});
            return true;
        }
        player.SendNotify(NotifyType.Error, "Не достаточно наличных средств!");
        return false;
    }
    public static bool MinusMoneyBank(Player player, int countMoney)
    {
        var character = player.GetCharacter();
        if (CharacterHandler.MinusMoney(character, countMoney))
        {
            player.TriggerCefEvent("SERVER::CEF:UPDATE_HUD", new {money = character.Money, moneyBank = character.MoneyBank});
            return true;
        }
        player.SendNotify(NotifyType.Error, "Не достаточно средств на карте!");
        return false;
    }

    public static void PlusMoney(Player player, int countMoney)
    {
        var character = player.GetCharacter();
        CharacterHandler.PlusMoney(character, countMoney);
        player.TriggerCefEvent("SERVER::CEF:UPDATE_HUD", new {money = character.Money, moneyBank = character.MoneyBank});
    }

    public static void PlusMoneyBank(Player player, int countMoney)
    {
        var character = player.GetCharacter();
        CharacterHandler.PlusMoneyBank(character, countMoney);
        player.TriggerCefEvent("SERVER::CEF:UPDATE_HUD", new {money = character.Money, moneyBank = character.MoneyBank});
    }
}