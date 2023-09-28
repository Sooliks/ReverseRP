using GTANetworkAPI;
using ServerSide.Enums;
using ServerSide.Extensions;
using ServerSide.Inventory.Enums;

namespace ServerSide.Services.AdminService;

public class AdminManager
{
    public static bool IsPlayerHaveAdminRank(Player player, AdminLevels adminLevels)
    {
        var account = player.GetAccount();
        if (account.AdminLvl >= (byte)adminLevels)
        {
            return true;
        }

        return false;
    }
}