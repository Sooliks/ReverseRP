using ClientSide.Enums;
using RAGE;
using RAGE.Elements;
using RAGE.Game;

namespace ClientSide.Services
{
    public class CameraService
    {
        public static Camera Camera;
        public static void SetCamera(Vector3 positionCamera,Vector3 pointCamAtCoord, bool toggle)
        {
            if (!toggle)
            {
                Cam.RenderScriptCams(false, false, 0,true, false, 0);
                Camera = null;
                return;
            }
            Camera = new Camera((ushort)Cam.CreateCameraWithParams(Misc.GetHashKey("DEFAULT_SCRIPTED_CAMERA"), positionCamera.X, positionCamera.Y, positionCamera.Z, 100f, 100f, 100f, 70.0f, true, 2), 0);
            Cam.PointCamAtCoord(Camera.Id, pointCamAtCoord.X, pointCamAtCoord.Y, pointCamAtCoord.Z);
            Cam.SetCamActive(Camera.Id, toggle);
            Cam.RenderScriptCams(true, false, 0,true, false, 0);
        }
        public static void SetCameraOnPlayer(TypeCameraOnPlayer typeCameraOnPlayer,bool toggle)
        {
            var player = RAGE.Elements.Player.LocalPlayer;
            switch (typeCameraOnPlayer)
            {
                case TypeCameraOnPlayer.Face:
                    SetCamera(Direction.GetDirection(new Vector3(player.Position.X, player.Position.Y, player.Position.Z+0.7f), player.GetRotation(0), 0.5f),
                        new Vector3(player.Position.X, player.Position.Y, player.Position.Z+0.7f), toggle); 
                    break;
                case TypeCameraOnPlayer.Body:
                    SetCamera(Direction.GetDirection(player.Position, player.GetRotation(0), 0.6f),
                        new Vector3(player.Position.X, player.Position.Y, player.Position.Z), toggle); 
                    break;
                case TypeCameraOnPlayer.Legs:
                    SetCamera(Direction.GetDirection(new Vector3(player.Position.X, player.Position.Y, player.Position.Z-0.7f), player.GetRotation(0), 0.6f),
                        new Vector3(player.Position.X, player.Position.Y, player.Position.Z-0.7f), toggle); 
                    break;
            }
        }
        public static void SetCameraOnPlayer(int typeCameraOnPlayer,bool toggle)
        {
            var player = RAGE.Elements.Player.LocalPlayer;
            switch (typeCameraOnPlayer)
            {
                case 0:
                    SetCamera(Direction.GetDirection(new Vector3(player.Position.X, player.Position.Y, player.Position.Z+0.7f), player.GetRotation(0), 0.5f),
                        new Vector3(player.Position.X, player.Position.Y, player.Position.Z+0.7f), toggle); 
                    break;
                case 1:
                    SetCamera(Direction.GetDirection(player.Position, player.GetRotation(0), 1.5f),
                        new Vector3(player.Position.X, player.Position.Y, player.Position.Z), toggle); 
                    break;
                case 2:
                    SetCamera(Direction.GetDirection(new Vector3(player.Position.X, player.Position.Y, player.Position.Z-0.7f), player.GetRotation(0), 0.6f),
                        new Vector3(player.Position.X, player.Position.Y, player.Position.Z-0.7f), toggle); 
                    break;
            }
        }
    }
}