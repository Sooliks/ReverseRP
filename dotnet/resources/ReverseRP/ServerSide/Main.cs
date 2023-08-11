using System;
using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;
using ServerSide.Database;
using ServerSide.Database.Models;
using ServerSide.Extensions;
using ServerSide.Inventory;
using ServerSide.Inventory.Items;
using ServerSide.Services;

namespace ServerSide;

public class Main : Script
{
    [ServerEvent(Event.ResourceStart)]
    public void OnResourceStart()
    {
        NAPI.Util.ConsoleOutput("Server started!");
        using (Context db = new Context())
        {
            try
            {
                bool isAvalaible = db.Database.CanConnect();
                NAPI.Util.ConsoleOutput(isAvalaible ? "Database success connected!" : "Database is unavailable!");
                var character = db.Character.SingleOrDefault(c => c.AccountId == 5);
                List<ItemBase> list = new List<ItemBase>();
                list.Add(new Food(1,"df","dgdg",5));
                character.Inventory = list;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                NAPI.Util.ConsoleOutput(e.ToString());
            }
        }
    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Player player)
    {
        player.ChangeCefWindow(CefWindowsPaths.Authorization);
        player.FreezePlayer(true);
    }
}