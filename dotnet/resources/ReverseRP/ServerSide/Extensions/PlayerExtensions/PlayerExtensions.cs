using GTANetworkAPI;
using Newtonsoft.Json;
using ServerSide.Enums;
using ServerSide.Services;
using ServerSide.Services.PlayerService;
using ServerSide.Services.ServerServices;

namespace ServerSide.Extensions;

public static class PlayerExtensions
{
    public static void ChangeCefWindow(this Player player, string path) => CefService.ChangePath(player,path);
    public static void TriggerCefEvent(this Player player, string eventName, params object[] args)=> player.TriggerEvent("REDIRECT::SERVER_TO_CEF",eventName, JsonConvert.SerializeObject(args));
    public static void SendNotify(this Player player,NotifyType notifyType, string message) => player.TriggerEvent("SERVER::CLIENT:ON_NOTIFY_PLAYER",(int)notifyType,message);
    public static void FreezePlayer(this Player player,bool toggle) => player.TriggerEvent("SERVER::CLIENT::FREEZE_PLAYER",toggle);
    public static void SetCamera(this Player player, Vector3 positionCamera, Vector3 pointCamAtCoord, bool active) => player.TriggerEvent("SERVER:CLIENT::SET_GENERAL_CAMERA", positionCamera, pointCamAtCoord, active);
    public static void SetCameraOnPlayer(this Player player,TypeCameraOnPlayer typeCameraOnPlayer, bool toggle) => PlayerCameraService.SetCameraOnPlayer(player,typeCameraOnPlayer, toggle);
    public static void DestroyMainCamera(this Player player) => PlayerCameraService.SetCameraOnPlayer(player, TypeCameraOnPlayer.Body,false);
    public static void SendProgressBar(this Player player, int seconds, string text = "") => player.TriggerEvent("SERVER::CLIENT:SHOW_PROGRESS_BAR", seconds,text);
    public static void SetUniqueDimension(this Player player) => DimensionService.SetUniqueDimension(player);
}