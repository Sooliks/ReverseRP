using System;
using System.Linq;
using GTANetworkAPI;
using ServerSide.Database;
using ServerSide.Database.Handlers;
using ServerSide.Extensions;
using ServerSide.Inventory.Enums;
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