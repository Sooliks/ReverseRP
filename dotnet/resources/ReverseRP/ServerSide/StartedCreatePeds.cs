using GTANetworkAPI;
using ServerSide.Enums;
using ServerSide.Extensions;
using ServerSide.Services.MapService;

namespace ServerSide;

public class StartedCreatePeds
{
    public static void LoadPeds()
    {
        InputMarker.CreateNpcWithCallback("csb_abigail", new Vector3(-40.83416,-1083.4673,26.601025), 68.11363f, "","Штраф стоянка", 50, 51, player=>player.SendChatMessage("открыт"));
    }
}