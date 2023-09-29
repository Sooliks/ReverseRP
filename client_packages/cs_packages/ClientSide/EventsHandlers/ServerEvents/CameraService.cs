using ClientSide.CEF;
using RAGE;
using RAGE.Elements;
using RAGE.Game;
using RAGE.Util;

namespace ClientSide.EventsHandlers.ServerEvents
{
    public class CameraService : Events.Script
    {
        public static Camera Camera { get; set; }
        public CameraService()
        {
            Events.Add("SERVER:CLIENT::SET_GENERAL_CAMERA", SetGeneralCamera);
            CefService.MainCefWindow.Call("SERVER:CEF::NOTIFY", Json.Serialize(new object[] {1, "dgdggd"} ));
        }
        private void SetGeneralCamera(object[] args)
        {
            Vector3 positionCamera = (Vector3)args[0];
            Vector3 pointCamAtCoord = (Vector3)args[1];
            bool active = (bool)args[2];
            Camera camera =
                new Camera((ushort)Cam.CreateCameraWithParams(Misc.GetHashKey("DEFAULT_SCRIPTED_CAMERA"), positionCamera.X, positionCamera.Y, positionCamera.Z, 100f, 100f, 100f, 70.0f, true, 2), 0);
            Cam.PointCamAtCoord(camera.Id, pointCamAtCoord.X, pointCamAtCoord.Y, pointCamAtCoord.Z);
            Cam.SetCamActive(camera.Id, active);
            Cam.RenderScriptCams(true, false, 0,true, false, 0);
        }
    }
}