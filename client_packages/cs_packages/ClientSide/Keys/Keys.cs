using ClientSide.CEF;
using ClientSide.EventsHandlers.PlayerEvents;
using RAGE;
using RAGE.Ui;

namespace ClientSide.Keys
{
    public class Keys : Events.Script
    {
        public Keys()
        {
            Input.Bind(VirtualKeys.F2, true, () =>
            {
                Cursor.ShowCursor(!Cursor.Visible,!Cursor.Visible);
            });
            Input.Bind(VirtualKeys.I, true, () =>
            {
                if(RAGE.Elements.Player.LocalPlayer.IsTypingInTextChat)return;
                CefService.SwapPath(CefService.MainCefWindow.Url == "http://localhost:3000/inventory" ? "" : "/inventory");
            });
            Input.Bind(VirtualKeys.P, true, () =>
            {
                if(RAGE.Elements.Player.LocalPlayer.IsTypingInTextChat)return;
                CefService.SwapPath(CefService.MainCefWindow.Url == "http://localhost:3000/phone" ? "" : "/phone");
            });
            Input.Bind(VirtualKeys.F4, true, () =>
            {
                Events.CallRemote("CLIENT:SERVER::OnTeleport", RAGE.Util.Json.Serialize(Waypoints.LastWaypointPosition));
            });
        }
    }
}