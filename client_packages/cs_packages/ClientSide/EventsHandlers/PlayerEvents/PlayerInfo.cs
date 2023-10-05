using RAGE;
using System.Threading.Tasks;

namespace ClientSide.EventsHandlers.PlayerEvents
{
    public class PlayerInfo : Events.Script
    {
        public PlayerInfo()
        {
            Events.AddProc("RPC::SERVER::CLIENT:IsPlayerAnimPlaying", OnIsPlayerAnimPlaying, true);
        }

        private async Task<bool> OnIsPlayerAnimPlaying(object[] args)
        {
            return RAGE.Elements.Player.LocalPlayer.IsPlayingAnim((string)args[0], (string)args[1], (int)args[2]);
        }
    }
}