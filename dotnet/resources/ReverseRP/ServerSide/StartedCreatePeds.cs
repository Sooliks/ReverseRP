using GTANetworkAPI;
using ServerSide.Services.MapService;

namespace ServerSide;

public class StartedCreatePeds
{
    public static void LoadPeds()
    {
        InputMarker.CreateNpcWithCallback("csb_abigail", new Vector3(), 30, "fg","Штраф стоянка", 10, 10, player=>player.SendChatMessage("открыт"));
    }
}