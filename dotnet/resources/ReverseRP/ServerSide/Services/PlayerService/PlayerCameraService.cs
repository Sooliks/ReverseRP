using Discord;
using GTANetworkAPI;
using ServerSide.Enums;
using ServerSide.Extensions;
using Direction = ServerSide.Services.PositionService.Direction;

namespace ServerSide.Services.PlayerService;

public class PlayerCameraService
{
    public static void SetCameraOnPlayer(Player player, TypeCameraOnPlayer typeCameraOnPlayer,bool toggle)
    {
        switch (typeCameraOnPlayer)
        {
            case TypeCameraOnPlayer.Face:
                player.SetCamera(Direction.GetDirection(new Vector3(player.Position.X, player.Position.Y, player.Position.Z+0.7f), player.Rotation, 0.5f),
                    new Vector3(player.Position.X, player.Position.Y, player.Position.Z+0.7f), toggle); 
                break;
            case TypeCameraOnPlayer.Body:
                player.SetCamera(Direction.GetDirection(player.Position, player.Rotation, 0.6f),
                    new Vector3(player.Position.X, player.Position.Y, player.Position.Z), toggle); 
                break;
            case TypeCameraOnPlayer.Legs:
                player.SetCamera(Direction.GetDirection(new Vector3(player.Position.X, player.Position.Y, player.Position.Z-0.7f), player.Rotation, 0.6f),
                    new Vector3(player.Position.X, player.Position.Y, player.Position.Z-0.7f), toggle); 
                break;
        }
    }
}