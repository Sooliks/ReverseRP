
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
            if (player.IsInVehicle)
            {
                player.SendChatMessage(NAPI.Util.ToJson(player.Vehicle.Position));
                if (name != "")
                    await DiscordBot.SendMessageInChannelAsync(DiscordBot.ChannelDevId,
                        $"Админ \"{player.GetAccount().Login}\" сохранил позицию на машине: \"{name}\": {NAPI.Util.ToJson(player.Vehicle.Position)}");
                else
                {
                    await DiscordBot.SendMessageInChannelAsync(DiscordBot.ChannelDevId, $"Админ \"{player.GetAccount().Login}\" сохранил позицию на машине: {NAPI.Util.ToJson(player.Vehicle.Position)}");
                }
                return;
            }
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

    [Command("veh","/veh [имя авто] [цвет 1?] [цвет 2?]", Alias = "vehicle")]
    public async Task OnSpawnVeh(Player player, string vehName, int color1 = 5, int color2 = 5)
    {
        if (player.IsHaveAdminRank(AdminLevels.SeniorModerator))
        {
            uint vehHash = NAPI.Util.GetHashKey(vehName);
            Vehicle veh = NAPI.Vehicle.CreateVehicle(vehHash, player.Position, player.Heading, color1, color2);
            veh.NumberPlate = "ADMINCAR";
            veh.Locked = false;
            veh.EngineStatus = true;
            player.SetIntoVehicle(veh, (int)VehicleSeat.Driver);
            await Logs.SendGameLogAsync($"Админ {player.GetAccount().Login} заспавнил авто, координаты: {NAPI.Util.ToJson(player.Position)}");
        }
        else
        {
            player.SendChatMessage("~r~Эта команда не доступна");
        }
    }
}