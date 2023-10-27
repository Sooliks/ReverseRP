using ClientSide.CEF;
using ClientSide.Services;
using RAGE;
using RAGE.Elements;
using RAGE.Game;
using RAGE.Util;

namespace ClientSide.EventsHandlers.ServerEvents
{
    public class CameraEvents : Events.Script
    {
        public CameraEvents()
        {
            Events.Add("SERVER:CLIENT::SET_GENERAL_CAMERA", SetGeneralCamera);
            
        }
        private void SetGeneralCamera(object[] args)
        {
            Vector3 positionCamera = (Vector3)args[0];
            Vector3 pointCamAtCoord = (Vector3)args[1];
            bool active = (bool)args[2];
            CameraService.SetCamera(positionCamera, pointCamAtCoord, active);
        }
    }
}