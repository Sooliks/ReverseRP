
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Enums;
using ServerSide.Extensions;

namespace ServerSide.Services.PlayerService;

public class PlayerMoneyService
{
    public static bool MinusMoney(Player player, int countMoney)
    {
        if (CharacterHandler.MinusMoney(player, countMoney))
        {
            return true;
        }
        player.SendNotify(NotifyType.Error, "Не достаточно средств!");
        return false;
    }
    public static bool MinusMoneyBank(Player player, int countMoney)
    {
        if (CharacterHandler.MinusMoney(player, countMoney))
        {
            return true;
        }
        player.SendNotify(NotifyType.Error, "Не достаточно средств!");
        return false;
    }
    public static void PlusMoney(Player player, int countMoney) => CharacterHandler.PlusMoney(player, countMoney);
    public static void PlusMoneyBank(Player player, int countMoney) => CharacterHandler.PlusMoneyBank(player, countMoney);
}