using System;
using GTANetworkAPI;
using ServerSide.Enums;
using ServerSide.Extensions;
using ServerSide.Extensions.VehicleExtensions;

namespace ServerSide.EventsHandlers.VehicleEvents;

public class EventsManagementVehicle : Script
{
    [RemoteEvent("CLIENT::SERVER:PRESS_CTRL_IN_VEHICLE")]
    public void OnPressCtrlInVehicle(Player player)
    {
        if(player.Vehicle == null)return;
        var vehicleModel = player.Vehicle.GetVehicleModel();
        if (player.Vehicle.EngineStatus)
        {
            player.Vehicle.EngineStatus = false;
            return;
        }
        if (vehicleModel == null || vehicleModel.Character.Id != player.GetCharacter().Id)
        {
            player.SendNotify(NotifyType.Warning, "У вас нет ключей!");
            return;
        }
        if (player.Vehicle.IsRefueling())
        {
            player.SendNotify(NotifyType.Warning, "Подождите пока машина заправиться!");
            return;
        }
        player.Vehicle.EngineStatus = true;
    }
}