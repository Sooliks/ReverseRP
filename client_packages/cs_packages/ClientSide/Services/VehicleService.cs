using RAGE;
using RAGE.Elements;
using System.Collections.Generic;

namespace ClientSide.Services
{
    public class VehicleService : Events.Script
    {
        private static float GeneralRpm { get; set; } = 0;
        public VehicleService()
        {
            Events.Tick += OnTick;
            Events.OnPlayerLeaveVehicle += OnPlayerLeaveVehicle;
        }
        private void OnTick(List<Events.TickNametagData> nametags)
        {
            if (Player.LocalPlayer.Vehicle != null)
            {
                var vehicle = Player.LocalPlayer.Vehicle;
                GeneralRpm += vehicle.Rpm;
                if (GeneralRpm > 750)
                {
                    Events.CallRemote("CLIENT::SERVER:ONE_TICK_FUEL");
                    GeneralRpm = 0;
                }
            }
            if(Player.LocalPlayer.Vehicle == null) GeneralRpm = 0;
        }

        private void OnPlayerLeaveVehicle(Vehicle vehicle, int seatId)
        {
            var engineStatus = (bool)vehicle.GetSharedData("vehicleEngineStatusKey");
            if(engineStatus==null)return;
            vehicle.SetEngineOn(engineStatus,true, true);
        }
    }
}