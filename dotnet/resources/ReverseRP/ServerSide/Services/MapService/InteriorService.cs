using GTANetworkAPI;
using ServerSide.Extensions;
using ServerSide.Services.ServerServices;

namespace ServerSide.Services.MapService;

public class InteriorService
{
    public static void ExitSoloInterior(Player player, uint dimension = 0)
    {
        player.DestroyMainCamera();
        player.Dimension = dimension;
        player.SetPlayerIsExitInterior(true);
        NAPI.Task.Run(() =>
        {
            player.SetPlayerIsExitInterior(false);
        },2000);
    }
}