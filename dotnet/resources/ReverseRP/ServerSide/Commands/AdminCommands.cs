using System;
using System.Threading.Tasks;
using Discord;
using GTANetworkAPI;
using ServerSide.Discord;
using ServerSide.Enums;
using ServerSide.Extensions;

namespace ServerSide.Commands;

public class AdminCommands : Script
{
    [Command("saveposition", Alias = "savepos")]
    public async Task OnSavePosition(Player player)
    {
        if (player.IsHaveAdminRank(AdminLevels.Helper))
        {
            player.SendChatMessage(NAPI.Util.ToJson(player.Position));
            await DiscordBot.SendMessageInChannelAsync(DiscordBot.ChannelDevId, NAPI.Util.ToJson(player.Position));
        }
        else
        {
            player.SendChatMessage("~r~Эта команда не доступна");
        }
    }
}