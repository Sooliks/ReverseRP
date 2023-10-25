using RAGE;
using System.Threading.Tasks;
using ClientSide.CEF;

namespace ClientSide.EventsHandlers.PlayerEvents
{
    public class PlayerInfo : Events.Script
    {
        public PlayerInfo()
        {
            Events.AddProc("RPC::SERVER::CLIENT:IsPlayerAnimPlaying", OnIsPlayerAnimPlaying, true);
            Events.AddProc("RPC::SERVER::CLIENT:GetCurrentCefPath",OnGetCurrentCefPath, true);
        }

        private async Task<bool> OnIsPlayerAnimPlaying(object[] args)
        {
            return RAGE.Elements.Player.LocalPlayer.IsPlayingAnim((string)args[0], (string)args[1], (int)args[2]);
        }
        private async Task<string> OnGetCurrentCefPath(object[] args)
        {
            return CefService.MainCefWindow.Url;
        }
    }
}