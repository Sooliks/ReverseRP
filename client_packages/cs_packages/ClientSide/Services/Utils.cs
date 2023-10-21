using ClientSide.CEF;
using ClientSide.Enums;


namespace ClientSide.Services
{
    public class Utils
    {
        public static void NotifyPlayer(NotifyType notifyType, string message)
        {
            var args = new object[] {notifyType, message};
            CefService.NotifyCefWindow.Call("SERVER:CEF::NOTIFY", RAGE.Util.Json.Serialize(args));
        }
    }
}