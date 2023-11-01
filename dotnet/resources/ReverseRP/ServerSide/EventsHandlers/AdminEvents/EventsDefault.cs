
using GTANetworkAPI;
using ServerSide.Enums;
using ServerSide.Extensions;


namespace ServerSide.EventsHandlers.AdminEvents;

public class EventsDefault : Script
{
    [RemoteEvent("CLIENT:SERVER::OnTeleport")]
    public void OnTeleport(Player player, string waypointPosJson)
    {
        if(waypointPosJson=="null")return;
        if(player.IsInVehicle)return;
        
        if (player.IsHaveAdminRank(AdminLevels.JuniorModerator))
        {
            player.Position = NAPI.Util.FromJson<Vector3>(waypointPosJson);
        }
    }
}