using GTANetworkAPI;
using ServerSide.Enums;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.PlayerEvents;

public class AdminEvents : Script
{
    [RemoteProc("RPC::CLIENT::SERVER:EnableNoClip")]
    public bool OnEnableNoClip(Player player)
    {
        if (player.IsAuthorized())
        {
            if (player.IsHaveAdminRank(AdminLevels.MiddleAdmin))
            {
                return true;
            }

            return false;
        }

        return false;
    }
}