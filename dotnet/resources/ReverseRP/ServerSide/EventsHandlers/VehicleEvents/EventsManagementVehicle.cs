using System;
using GTANetworkAPI;
using ServerSide.Enums;
using ServerSide.Extensions;
using ServerSide.Extensions.VehicleExtensions;

namespace ServerSide.EventsHandlers.VehicleEvents;

public class EventsManagementVehicle : Script
{
    [RemoteEvent("CLIENT::SERVER:PRESS_ALT_IN_VEHICLE")]
    public async void OnPressCtrlInVehicle(Player player)
    {
        if(player.Vehicle == null)return;
        string path = await player.GetCurrentCefPath();
        if (path.Split('/').Length > 3)
        {
            if(path.Split('/')[3] == "gasstation") return;
        }
        if (player.Vehicle.EngineStatus)
        {
            player.Vehicle.EngineStatus = false;
            return;
        }
        var vehicleModel = player.Vehicle.GetVehicleModel();
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