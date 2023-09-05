using GTANetworkAPI;
using Newtonsoft.Json;
using ServerSide.Enums;
using ServerSide.Services;

namespace ServerSide.Extensions;

public static class PlayerExtensions
{
    public static void ChangeCefWindow(this Player player, string path) => CefService.ChangePath(player,path);
    public static void TriggerCefEvent(this Player player, string eventName, params object[] args)
    {
        player.TriggerEvent("REDIRECT::SERVER_TO_CEF",eventName,JsonConvert.SerializeObject(args));
    }
    public static void SendNotify(this Player player,NotifyType notifyType, string message)
    {
        player.TriggerCefEvent("SERVER::CEF::NOTIFY",(int)notifyType,message);
    }
    public static void FreezePlayer(this Player player,bool toggle)
    {
        player.TriggerEvent("SERVER::CLIENT::FREEZE_PLAYER",toggle);
    }
    public static void SetCamera(this Player player, Vector3 positionCamera, Vector3 pointCamAtCoord, bool active)
    {
        player.TriggerEvent("SERVER|CEF::CLIENT::SET_GENERAL_CAMERA", positionCamera, pointCamAtCoord, active);
    }
}