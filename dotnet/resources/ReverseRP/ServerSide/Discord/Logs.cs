using System;
using System.Threading.Tasks;

namespace ServerSide.Discord;

public class Logs
{
    public static async Task SendGameLogAsync(string message) => await DiscordBot.SendMessageInChannelAsync(DiscordBot.ChannelGameLogsId,$"{message} || DataTime: {DateTime.Now}");
}