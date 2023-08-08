using RAGE;
using RAGE.Game;


namespace ClientSide.EventsHandlers.ServerEvents
{
    public class ManagementPlayer : Events.Script
    {
        public ManagementPlayer()
        {
            Events.Add("SERVER::CLIENT::FREEZE_PLAYER",FreezePlayer);
        }
        private void FreezePlayer(object[] args)
        {
            RAGE.Elements.Player.LocalPlayer.FreezePosition((bool)args[0]);
        }
    }
}