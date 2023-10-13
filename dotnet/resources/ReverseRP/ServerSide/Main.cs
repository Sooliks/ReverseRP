using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GTANetworkAPI;
using Newtonsoft.Json;
using ServerSide.Data;
using ServerSide.Database;
using ServerSide.Database.Handlers;
using ServerSide.Database.Models;
using ServerSide.Discord;
using ServerSide.Extensions;
using ServerSide.Services;
using ServerSide.Services.MapService;
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
        NAPI.Server.SetDefaultSpawnLocation(new Vector3(30.660997, -1345.5656, 29.497015));
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
        using (var r = new StreamReader("dotnet/resources/ReverseRP/ServerSide/Data/markers.json"))
        {
            string json = r.ReadToEnd();
            var markers = JsonConvert.DeserializeObject<List<MarkerModel>>(json);
            foreach (var marker in markers)
            {
                InputMarker.CreateDefaultInputMarkerWithOpenCefPath(marker.TextLabel, marker.Position, marker.IconBlip, marker.ColorBlip, marker.NameCefPath);
            }
        }
        foreach (var business in BusinessHandler.GetAllBusinesses())
        {
            InputMarker.CreateDefaultInputMarkerWithFuncCallbackWithoutBlip("Информация", business.PositionManagementBusiness,
                player =>
                {
                    if (BusinessHandler.IsCharacterOwnerBusiness(player.GetCharacter(), BusinessHandler.GetBusinessById(business.Id)))
                    {
                        player.ChangeCefWindow($"/managementbusiness/{business.Id}");
                    }
                });
        }
        await Task.Delay(1000);
        await Logs.SendGameLogAsync("Server started!");
    }

    [ServerEvent(Event.PlayerConnected)]
    public async void OnPlayerConnected(Player player)
    {
        player.ChangeCefWindow(CefWindowsPaths.Authorization);
        player.FreezePlayer(true);
        await DiscordBot.GetUserCount();
    }

    [ServerEvent(Event.PlayerDisconnected)]
    public async void OnPlayerDisconnected(Player player, DisconnectionType type, string reason)
    {
        await DiscordBot.GetUserCount();
    }

    [ServerEvent(Event.ResourceStop)]
    public async void OnResourceStop()
    {
        await Logs.SendGameLogAsync("Server stopped!");
    }
}