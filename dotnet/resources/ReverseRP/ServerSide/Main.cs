using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NLog;
using ServerSide.Database;
using ServerSide.Database.Models;
using ServerSide.Discord;
using ServerSide.Extensions;
using ServerSide.Inventory.Enums;
using ServerSide.Inventory.Items;
using ServerSide.Services;
using ServerSide.Services.MapService;


namespace ServerSide;

public class Main : Script
{
    public static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    
    [ServerEvent(Event.ResourceStart)]
    public async void OnResourceStart()
    {
        NAPI.Util.ConsoleOutput("Server started!");
        await DiscordBot.StartDiscordBot();
        NAPI.Server.SetGlobalServerChat(false);
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
                NAPI.Util.ConsoleOutput(e.ToString());
            }
            /*var character = db.Character.Include(c=>c.Inventory).SingleOrDefault(c => c.Id == 1);
            character.Inventory.Add(new Food(1,"Бургер", "Восполняет", 1, 3535));
            character.Inventory.Add(new Ammo(1,"Бургер", "Восполняет", 1, TypeAmmo.Rifle, 435));
            character.Inventory.Add(new ItemBase(1,"Бургер", "Восполняет", 1,  435));
            db.SaveChanges();*/
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
}