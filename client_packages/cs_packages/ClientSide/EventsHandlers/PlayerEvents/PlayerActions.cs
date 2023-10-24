using ClientSide.CEF;
using RAGE;

namespace ClientSide.EventsHandlers.PlayerEvents
{
    public class PlayerActions : Events.Script
    {
        public PlayerActions()
        {
            Events.Add("SERVER::CLIENT:SHOW_PROGRESS_BAR",OnShowProgressBar);
            Events.Add("SERVER::CLIENT:ON_NOTIFY_PLAYER",OnNotifyPlayer);
        }

        private void OnNotifyPlayer(object[] args)
        {
            CefService.NotifyCefWindow.Call("SERVER:CEF::NOTIFY", RAGE.Util.Json.Serialize(args));
        }

        private void OnShowProgressBar(object[] args)
        {
            CefService.ProgressBarCefWindow.Active = true;
            CefService.ProgressBarCefWindow.Call("CLIENT::CEF:SHOW_PROGRESS_BAR", args[0], args[1]);
        }
    }
}