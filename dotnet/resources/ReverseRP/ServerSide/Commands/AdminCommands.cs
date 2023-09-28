using GTANetworkAPI;
using ServerSide.Enums;
using ServerSide.Extensions;

namespace ServerSide.Commands;

public class AdminCommands : Script
{
    [Command("saveposition", Alias = "savepos")]
    public void OnSavePosition(Player player)
    {
        if (player.IsHaveAdminRank(AdminLevels.Helper))
        {
            player.SendChatMessage(NAPI.Util.ToJson(player.Position));
        }
        else
        {
            player.SendChatMessage("~r~Эта команда не доступна");
        }
    }
}