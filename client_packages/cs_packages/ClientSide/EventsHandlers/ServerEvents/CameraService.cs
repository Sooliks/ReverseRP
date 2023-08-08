using RAGE;
using RAGE.Elements;
using RAGE.Game;

namespace ClientSide.EventsHandlers.ServerEvents
{
    public class CameraService : Events.Script
    {
        public static Camera Camera { get; set; }
        public CameraService()
        {
            Events.Add("SERVER|CEF::CLIENT::SET_GENERAL_CAMERA",SetGeneralCamera);
        }
        private void SetGeneralCamera(object[] args)
        {
            Vector3 positionCamera = (Vector3)args[0];
            Vector3 pointCamAtCoord = (Vector3)args[1];
            bool active = (bool)args[3];
            Camera = new Camera(
                    (ushort)Cam.CreateCameraWithParams(Misc.GetHashKey("DEFAULT_SCRIPTED_CAMERA"), positionCamera.X,
                        positionCamera.Y, positionCamera.Z, 100, 100, 100, 70.0f, true, 2), 0);
            Cam.PointCamAtCoord(Camera.Id, pointCamAtCoord.X, pointCamAtCoord.Y, pointCamAtCoord.Z);
            Cam.SetCamActive(Camera.Id, active);
            Cam.RenderScriptCams(true, false, 0,true, false, 0);
            
        }
    }
}