using RAGE;
using RAGE.Ui;
using System.Collections.Generic;
using ClientSide.Enums;
using ClientSide.Services;
using RAGE.Elements;
using RAGE.Game;
using RAGE.NUI;
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
                    Player.LocalPlayer.SetVisible(true,false);
                    return;
                }
                if(Player.LocalPlayer.Vehicle!=null)return;
                

                bool isAcceptedNoClip = (bool) await Events.CallRemoteProc("RPC::CLIENT::SERVER:EnableNoClip");
                if (isAcceptedNoClip)
                {
                    Speed = 0.5f;
                    NoClipIsEnabled = true;
                    Utils.NotifyPlayer(NotifyType.Info,"Noclip включен");
                    Player.LocalPlayer.FreezePosition(true);
                    Player.LocalPlayer.SetVisible(false,false);
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
                if(Speed>=10.0f)return;
                Speed += 0.08f;
            });
            Input.Bind(VirtualKeys.Down, true, async () =>
            {
                if(Speed<=0.1f)return;
                Speed -= 0.08f;
            });
        }

        private void OnTick(List<Events.TickNametagData> nametags)
        {
            if (NoClipIsEnabled)
            {
                if (KeyShiftIsHolding)
                {
                    Player.LocalPlayer.Position = new Vector3(Player.LocalPlayer.Position.X, Player.LocalPlayer.Position.Y, Player.LocalPlayer.Position.Z += Speed);
                }
                if (KeyCtrlIsHolding)
                {
                    Player.LocalPlayer.Position = new Vector3(Player.LocalPlayer.Position.X, Player.LocalPlayer.Position.Y, Player.LocalPlayer.Position.Z -= Speed);
                }
                if (KeyWIsHolding)
                {
                    var posLookAt = Direction.GetDirection(Player.LocalPlayer.Position, Cam.GetGameplayCamRot(0), Speed);
                    Player.LocalPlayer.Position = new Vector3(posLookAt.X, posLookAt.Y, posLookAt.Z);
                    
                }
            }
        }
    }
}