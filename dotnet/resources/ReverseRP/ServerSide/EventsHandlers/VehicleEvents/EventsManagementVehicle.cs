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
        if (player.Vehicle.IsRefueling())
        {
            player.SendNotify(NotifyType.Warning, "Подождите пока машина заправиться!");
            return;
        }
        if (player.IsHaveAdminRank(AdminLevels.SeniorAdmin))
        {
            player.Vehicle.EngineStatus = !player.Vehicle.EngineStatus;
            return;
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
        player.Vehicle.EngineStatus = true;
    }

    [RemoteEvent("CLIENT::SERVER:PRESS_L")]
    public void OnPressL(Player player)
    {
        if (player.IsInVehicle)
        {
            if(player.Vehicle.GetVehicleModel()==null)return;
            if (player.Vehicle.GetVehicleModel().Character.Id == player.GetCharacter().Id)
            {
                player.Vehicle.Locked = !player.Vehicle.Locked;
                player.SendNotify(NotifyType.Info, player.Vehicle.Locked ? "Т/с закрыто!" : "Т/с открыто!");
            }
            return;
        }
        foreach (var vehicle in NAPI.Pools.GetAllVehicles())
        {
            if (player.Position.DistanceTo(vehicle.Position) < 7f)
            {
                if(vehicle.GetVehicleModel()==null)return;
                if (vehicle.GetVehicleModel().Character.Id == player.GetCharacter().Id)
                {
                    vehicle.Locked = !vehicle.Locked;
                    player.SendNotify(NotifyType.Info, vehicle.Locked ? "Т/с закрыто!" : "Т/с открыто!");
                    return;
                }
            }
        }
    }

    [RemoteEvent("CLIENT::SERVER:ONE_TICK_FUEL")]
    public void OnOneTickFuel(Player player)
    {
        
    }
}