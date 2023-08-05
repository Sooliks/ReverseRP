using GTANetworkAPI;

namespace ServerSide.Services;

public class CefService : Script
{
    public static void ChangePath(Player player,string path)
    {
        player.TriggerEvent("SERVER::CLIENT::CHANGE_WINDOW",path);
    }
}

