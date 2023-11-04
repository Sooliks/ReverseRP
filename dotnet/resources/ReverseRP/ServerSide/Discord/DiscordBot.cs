using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using GTANetworkAPI;


namespace ServerSide.Discord;

public class DiscordBot
{
    public DiscordBot()
    {
        
    }
    public static DiscordSocketClient Client;
    public readonly static ulong ChannelDevId = 1157652166580908052;
    public readonly static ulong ChannelGameLogsId = 1080966670329335929;
    private const string Token = "MTAzOTkxNjIwMzQyODMwMjkwOA.Gz79Ss.dv_T2e4_n4Gy4eMfxw6NzrGHwmdVrQIZ8u5pBU";
    private const ulong Guild = 1039165715623710790;
    public static async Task StartDiscordBot()
    {
        try
        {
            Client = new DiscordSocketClient();
            await Client.LoginAsync(TokenType.Bot, Token);
            await Client.StartAsync();
            await Client.SetGameAsync("ReverseRP");
            Client.Log += DiscordBotLog;
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput("[Discord Bot]-> "+ex.ToString());
        }
    }

    
    public static Task DiscordBotLog(LogMessage message)
    {
        NAPI.Util.ConsoleOutput("[Discord Bot]-> "+message.ToString());
        return Task.CompletedTask;
    }

    public static async Task UpdateUserCount()
    {
        var memberCountTextChannel = Client.GetGuild(Guild).GetTextChannel(1039165715623710792);
        await memberCountTextChannel.ModifyAsync(p=>p.Name = $"Онлайн {NAPI.Pools.GetAllPlayers().Count}");
    }
    public static async Task SendMessageInChannelAsync(ulong channelId, string message) //1
    {
        var channel = Client.GetGuild(Guild).GetTextChannel(channelId);
        await channel.SendMessageAsync(message);
    }
    
}