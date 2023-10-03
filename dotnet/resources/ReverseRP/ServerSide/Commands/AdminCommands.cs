
using System.Threading.Tasks;
using GTANetworkAPI;
using ServerSide.Discord;
using ServerSide.Enums;
using ServerSide.Extensions;

namespace ServerSide.Commands;

public class AdminCommands : Script
{
    [Command("saveposition", Alias = "savepos")]
    public async Task OnSavePosition(Player player, string name = "")
    {
        if (player.IsHaveAdminRank(AdminLevels.Helper))
        {
            player.SendChatMessage(NAPI.Util.ToJson(player.Position));
            if (name != "")
                await DiscordBot.SendMessageInChannelAsync(DiscordBot.ChannelDevId,
                    $"Админ \"{player.GetAccount().Login}\" сохранил позицию \"{name}\": {NAPI.Util.ToJson(player.Position)}");
            else
            {
                await DiscordBot.SendMessageInChannelAsync(DiscordBot.ChannelDevId, $"Админ \"{player.GetAccount().Login}\" сохранил позицию: {NAPI.Util.ToJson(player.Position)}");
            }
        }
        else
        {
            player.SendChatMessage("~r~Эта команда не доступна");
        }
    }
}