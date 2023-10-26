using Discord;
using GTANetworkAPI;
using ServerSide.Extensions;
using Direction = ServerSide.Services.PositionService.Direction;

namespace ServerSide.Services.PlayerService;

public class PlayerCameraService
{
    public static void SetCameraOnPlayer(Player player,bool toggle)
    {
        player.SetCamera(Direction.GetDirection(player.Position, player.Rotation, 4f),
            new Vector3(player.Position.X, player.Position.Y, player.Position.Z), toggle);  
    }
}