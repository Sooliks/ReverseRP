using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using GTANetworkAPI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.CompilerServices;

namespace ServerSide.Discord;

public class DiscordBot
{
    public DiscordBot()
    {
        
    }
    public static DiscordSocketClient Client;
    public readonly static ulong ChannelDevId = 1157652166580908052;
    private static CommandService Commands;
    private static IServiceProvider Services;
    private readonly static string Token = "MTAzOTkxNjIwMzQyODMwMjkwOA.Gz79Ss.dv_T2e4_n4Gy4eMfxw6NzrGHwmdVrQIZ8u5pBU";
    public static async Task StartDiscordBot()
    {
        try
        {
            Client = new DiscordSocketClient();
            Commands = new CommandService();
            Services = new ServiceCollection()
                .AddSingleton(Client)
                .AddSingleton(Commands)
                .BuildServiceProvider();

            Client.Log += DiscordBotLog;
            await Client.LoginAsync(TokenType.Bot, Token);

            await Client.StartAsync();

            await Client.SetGameAsync("ReverseRP");
            
            
            await RegisterMessage();

            await Task.Delay(-1);

            await GetUserCount();
            
            
        }
        catch (Exception ex)
        {
            NAPI.Util.ConsoleOutput("[Discord Bot]-> "+ex.ToString());
        }
    }

    private static async Task RegisterMessage()
    {
        Client.MessageReceived += MessageHandler;
        await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), Services);
    }

    private static Task MessageHandler(SocketMessage messageParam)
    {
        messageParam.Channel.SendMessageAsync(messageParam.Content);
        return Task.CompletedTask;
    }

    public static Task DiscordBotLog(LogMessage message)
    {
        NAPI.Util.ConsoleOutput("[Discord Bot]-> "+message.ToString());
        return Task.CompletedTask;
    }

    public static async Task GetUserCount()
    {
        SocketTextChannel memberCount = Client.GetGuild(1039165715623710790).GetTextChannel(1039165715623710792);
        await memberCount.ModifyAsync(prop => prop.Name = $"Онлайн: {NAPI.Pools.GetAllPlayers().Count}");
    }
    public static async Task SendMessageInChannelAsync(ulong channelId, string message) //1
    {
        var channel = Client.GetGuild(1039165715623710790).GetTextChannel(1039165715623710792) as IMessageChannel; 
        await channel!.SendMessageAsync(message); 
    }
}