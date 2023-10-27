using ClientSide.Services;
using RAGE;

namespace ClientSide.EventsHandlers
{
    public class CameraEvents : Events.Script
    {
        public CameraEvents()
        {
            Events.Add("CEF::CLIENT:SetCameraOnPlayer",OnSetCameraOnPlayer);
        }

        private void OnSetCameraOnPlayer(object[] args)
        {
            CameraService.SetCameraOnPlayer((int)args[0], true);
        }
    }
}