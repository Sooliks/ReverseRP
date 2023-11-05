using System;
using System.Linq;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Enums;
using ServerSide.Extensions;
using ServerSide.Extensions.VehicleExtensions;
using ServerSide.Services;
using ServerSide.Services.VehicleServices;

namespace ServerSide.EventsHandlers.VehicleEvents;

public class EventsManagementVehicle : Script
{
    [RemoteEvent("CLIENT::SERVER:PRESS_ALT_IN_VEHICLE")]
    public async void OnPressCtrlInVehicle(Player player)
    {
        if(player.Vehicle == null)return;
        if(player.VehicleSeat != (int)VehicleSeat.Driver)return;
        string path = await player.GetCurrentCefPath();
        if (path.Split('/').Length > 3)
        {
            if(path.Split('/')[3] == "gasstation") return;
        }
        var vehicleModel = player.Vehicle.GetVehicleModelFromDb();
        if (vehicleModel != null)
        {
            if (vehicleModel.FuelTank < 0.3f)
            {
                player.SendNotify(NotifyType.Warning, "Топливо закончилось!");
                return;
            }
        }

        if (player.Vehicle.IsRefueling())
        {
            player.SendNotify(NotifyType.Warning, "Подождите пока машина заправиться!");
            return;
        }
        if (player.IsHaveAdminRank(AdminLevels.SeniorAdmin))
        {
            player.Vehicle.EngineStatus = !player.Vehicle.EngineStatus;
            player.Vehicle.SetSharedData("vehicleEngineStatusKey", player.Vehicle.EngineStatus);
            return;
        }
        if (player.Vehicle.EngineStatus)
        {
            player.Vehicle.EngineStatus = false;
            player.Vehicle.SetSharedData("vehicleEngineStatusKey", false);
            return;
        }
        if (vehicleModel == null || vehicleModel.Character.Id != player.GetCharacter().Id)
        {
            player.SendNotify(NotifyType.Warning, "У вас нет ключей!");
            return;
        }
        player.Vehicle.EngineStatus = true;
        player.Vehicle.SetSharedData("vehicleEngineStatusKey", true);
    }

    [RemoteEvent("CLIENT::SERVER:PRESS_L")]
    public void OnPressL(Player player)
    {
        if (player.IsInVehicle)
        {
            if(player.Vehicle.GetVehicleModelFromDb()==null)return;
            if (player.Vehicle.GetVehicleModelFromDb().Character.Id == player.GetCharacter().Id)
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
                if(vehicle.GetVehicleModelFromDb()==null)return;
                if (vehicle.GetVehicleModelFromDb().Character.Id == player.GetCharacter().Id)
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
        if (player.Vehicle != null)
        {
            if(player.VehicleSeat != (int)VehicleSeat.Driver)return;
            var vehicleModel = player.Vehicle.GetVehicleModelFromDb();
            if (vehicleModel != null)
            {
                if (vehicleModel.FuelTank < 0.3f)
                {
                    player.Vehicle.EngineStatus = false;
                    player.Vehicle.SetSharedData("vehicleEngineStatusKey", false);
                    return;
                }
                vehicleModel.MinusFuel();
                player.SendChatMessage(vehicleModel.FuelTank.ToString());
            }
        }
    }

    [RemoteEvent("CEF::SERVER:GET_VEHICLE_FROM_PARKING")]
    public void OnGetVehicleFromParking(Player player, int idVehicle, int idParking)
    {
        var vehicleModel = VehicleHandler.GetVehicleModelById(idVehicle);
        if (NAPI.Pools.GetAllVehicles().FirstOrDefault(v => v.GetVehicleModel().Id == vehicleModel.Id) != null)
        {
            player.ChangeCefWindow(CefWindowsPaths.Default);
            player.SendNotify(NotifyType.Warning, "Этот транспорт уже находится на сервере!");
            return;
        }
        player.ChangeCefWindow(CefWindowsPaths.Default);
        var positionAndRotationVehicleSpawn = ParkingService.GetRandomPositionParking(idParking);
        vehicleModel.VehicleRage.Spawn(positionAndRotationVehicleSpawn.Position, positionAndRotationVehicleSpawn.Rotation.Z);
    }

    [ServerEvent(Event.PlayerExitVehicle)]
    public void OnPlayerExitVehicle(Player player, Vehicle vehicle)
    {
        vehicle.SetSharedData("vehicleEngineStatusKey", vehicle.EngineStatus);
    }
    [ServerEvent(Event.PlayerEnterVehicle)]
    public void OnPlayerEnterVehicle(Player player, Vehicle vehicle, sbyte seatId)
    {
        vehicle.SetSharedData("vehicleEngineStatusKey", vehicle.EngineStatus);
    }
}