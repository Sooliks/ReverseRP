using GTANetworkAPI;
using ServerSide.Extensions;

namespace ServerSide.Services.PlayerService;

public class PlayerCameraService
{
    public static void SetCameraOnPlayer(Player player,bool toggle)
    {
        player.SetCamera(new Vector3(player.Position.X+0.6f, player.Position.Y+1.9f, player.Position.Z+0.5f),
            new Vector3(player.Position.X, player.Position.Y, player.Position.Z), toggle);  
    }
}