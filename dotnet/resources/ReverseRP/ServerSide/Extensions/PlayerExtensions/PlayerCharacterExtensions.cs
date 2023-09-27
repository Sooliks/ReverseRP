using GTANetworkAPI;
using ServerSide.Services.PlayerService;

namespace ServerSide.Extensions;

public static class PlayerCharacterExtensions
{
    public static bool MinusMoney(this Player player, int countMoney) => PlayerMoneyService.MinusMoney(player, countMoney);
    public static void PlusMoney(this Player player, int countMoney) => PlayerMoneyService.PlusMoney(player, countMoney);
    public static bool MinusMoneyBank(this Player player, int countMoney) => PlayerMoneyService.MinusMoneyBank(player, countMoney);
    public static void PlusMoneyBank(this Player player, int countMoney) => PlayerMoneyService.PlusMoneyBank(player, countMoney);
}