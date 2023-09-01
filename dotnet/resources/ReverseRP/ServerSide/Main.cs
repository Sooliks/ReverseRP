using System;
using GTANetworkAPI;
using NLog;
using ServerSide.Database;
using ServerSide.Extensions;
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
        }
    }

    [ServerEvent(Event.PlayerConnected)]
    public void OnPlayerConnected(Player player)
    {
        player.ChangeCefWindow(CefWindowsPaths.Authorization);
        player.FreezePlayer(true);
    }
}