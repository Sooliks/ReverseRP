using System;
using System.Linq;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore;
using NLog;
using ServerSide.Database;
using ServerSide.Database.Models;
using ServerSide.Extensions;
using ServerSide.Inventory.Enums;
using ServerSide.Inventory.Items;
using ServerSide.Services;


namespace ServerSide;

public class Main : Script
{
    public static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    
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
    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Player player)
    {
        player.ChangeCefWindow(CefWindowsPaths.Authorization);
        player.FreezePlayer(true);
    }
}