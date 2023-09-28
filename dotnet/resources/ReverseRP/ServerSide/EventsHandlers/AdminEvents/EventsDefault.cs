using GTANetworkAPI;
using ServerSide.Extensions;
using ServerSide.Inventory.Enums;

namespace ServerSide.EventsHandlers.Player;

public class EventsDefault
{
    [RemoteEvent("CLIENT:SERVER::OnTeleport")]
    public async void OnClickCreateCharacter(GTANetworkAPI.Player player, Vector3 waypointPos)
    {
        if (player.IsHaveAdminRank(AdminLevels.JuniorModerator))
        {
            player.Position = waypointPos;
        }
    }
}