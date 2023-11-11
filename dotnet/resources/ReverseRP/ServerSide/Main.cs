using System;
using GTANetworkAPI;
using ServerSide.Database;
using ServerSide.Discord;
using ServerSide.Extensions;
using ServerSide.Services;
using Task = System.Threading.Tasks.Task;


namespace ServerSide;

public class Main : Script
{
    [ServerEvent(Event.ResourceStart)]
    public async Task OnResourceStart()
    {
        NAPI.Util.ConsoleOutput("Server started!");
        await DiscordBot.StartDiscordBot();
        NAPI.Server.SetGlobalServerChat(false);
        //NAPI.Server.SetDefaultSpawnLocation(new Vector3(30.660997, -1345.5656, 29.497015));
        var datetime = DateTime.Now;
        NAPI.World.SetTime(datetime.Hour, datetime.Minute, datetime.Second);
        await using (var db = new Context())
        {
            try
            {
                bool isAvalaible = db.Database.CanConnect();
                NAPI.Util.ConsoleOutput(isAvalaible ? "Database success connected!" : "Database is unavailable!");
            }
            catch (Exception e)
            {
                NAPI.Util.ConsoleOutput("[Database]-> "+e.ToString());
                return;
            }
        }
        StartedCreateMarkers.LoadMarkers();
        StartedCreatePeds.LoadPeds();
        await Task.Delay(1000);
        await Logs.SendGameLogAsync("Server started!");
    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Player player)
    {
        player.ChangeCefWindow(CefWindowsPaths.Authorization);
        player.FreezePlayer(true);
        player.SetUniqueDimension();
        DiscordBot.UpdateUserCount();
    }

    [ServerEvent(Event.PlayerDisconnected)]
    public async void OnPlayerDisconnected(Player player, DisconnectionType type, string reason)
    {
        player.SetAuthorized(false);
        player.DestroyMainCamera();
        await DiscordBot.UpdateUserCount();
    }

    [ServerEvent(Event.ResourceStop)]
    public async void OnResourceStop()
    {
        await Logs.SendGameLogAsync("Server stopped!");
    }
}