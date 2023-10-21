using RAGE;
using RAGE.Ui;
using System.Collections.Generic;
using ClientSide.Enums;
using RAGE.Elements;
using RAGE.Game;
using Player = RAGE.Elements.Player;
using Utils = ClientSide.Services.Utils;

namespace ClientSide.EventsHandlers.PlayerEvents
{
    public class NoClip : Events.Script
    {
        private static bool NoClipIsEnabled { get; set; } = false;
        private static bool KeyWIsHolding { get; set; } = false;
        private static bool KeyAIsHolding { get; set; } = false;
        private static bool KeyDIsHolding { get; set; } = false;
        private static bool KeyCtrlIsHolding { get; set; } = false;
        private static bool KeyShiftIsHolding { get; set; } = false;
        private static float Speed { get; set; } = 0.5f;
        private static Camera Camera { get; set; }

        public NoClip()
        {
            Events.Tick += OnTick;
            Input.Bind(VirtualKeys.F3, true, async () =>
            {
                if (NoClipIsEnabled)
                {
                    NoClipIsEnabled = !NoClipIsEnabled;
                    Player.LocalPlayer.FreezePosition(false);
                    Utils.NotifyPlayer(NotifyType.Info,"Noclip выключен");
                    return;
                }
                bool isAcceptedNoClip = (bool) await Events.CallRemoteProc("RPC::CLIENT::SERVER:EnableNoClip");
                if (isAcceptedNoClip)
                {
                    NoClipIsEnabled = true;
                    Utils.NotifyPlayer(NotifyType.Info,"Noclip включен");
                    Camera = new Camera((ushort)Cam.CreateCameraWithParams(Misc.GetHashKey("DEFAULT_SCRIPTED_CAMERA"), Player.LocalPlayer.Position.X, Player.LocalPlayer.Position.Y, Player.LocalPlayer.Position.Z, Player.LocalPlayer.GetRotationVelocity().X, Player.LocalPlayer.GetRotationVelocity().Y, Player.LocalPlayer.GetRotationVelocity().Z, 70.0f, false, 2), 0);
                    Cam.SetCamActive(Camera.Id, true);
                    Cam.RenderScriptCams(true, false, 0,true, false, 0);
                }
            });
            Input.Bind(VirtualKeys.W, true, async () => KeyWIsHolding = true);
            Input.Bind(VirtualKeys.A, true, async () => KeyAIsHolding = true);
            Input.Bind(VirtualKeys.D, true, async () => KeyDIsHolding = true);
            Input.Bind(VirtualKeys.LeftControl, true, async () => KeyCtrlIsHolding = true);
            Input.Bind(VirtualKeys.LeftShift, true, async () => KeyShiftIsHolding = true);
            
            Input.Bind(VirtualKeys.W, false, async () => KeyWIsHolding = false);
            Input.Bind(VirtualKeys.A, false, async () => KeyAIsHolding = false);
            Input.Bind(VirtualKeys.D, false, async () => KeyDIsHolding = false);
            Input.Bind(VirtualKeys.LeftControl, false, async () => KeyCtrlIsHolding = false);
            Input.Bind(VirtualKeys.LeftShift, false, async () => KeyShiftIsHolding = false);
            
            Input.Bind(VirtualKeys.Up, true, async () =>
            {
                if(Speed==5.0f)return;
                Speed += 0.1f;
            });
            Input.Bind(VirtualKeys.Down, true, async () =>
            {
                if(Speed==0.1f)return;
                Speed -= 0.1f;
            });
        }

        private void OnTick(List<Events.TickNametagData> nametags)
        {
            if (NoClipIsEnabled)
            {
                Player.LocalPlayer.FreezePosition(true);
                var position = RAGE.Elements.Player.LocalPlayer.Position;
                if (KeyShiftIsHolding)
                {
                    Camera.Position = new Vector3(position.X, position.Y, position.Z += Speed);
                }
                if (KeyCtrlIsHolding)
                {
                    Camera.Position = new Vector3(position.X, position.Y, position.Z -= Speed);
                }
                if (KeyWIsHolding)
                {
                    Camera.Position = new Vector3(position.X+=Speed, position.Y+=Speed, position.Z);
                }
            }
        }
    }
}