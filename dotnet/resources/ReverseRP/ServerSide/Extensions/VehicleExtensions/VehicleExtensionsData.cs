using ServerSide.Database.Handlers;
using ServerSide.Database.Models;

namespace ServerSide.Extensions.VehicleExtensions;

public static class VehicleExtensionsData
{
    public static void SetVehicleModel(this GTANetworkAPI.Vehicle vehicle, Vehicle vehModel) => vehicle.SetData("vehicleModel", vehModel);
    public static Vehicle GetVehicleModelFromDb(this GTANetworkAPI.Vehicle  vehicle)
    {
        if (vehicle.HasData("vehicleModel"))
        {
            var v = vehicle.GetData<Vehicle>("vehicleModel");
            return VehicleHandler.GetVehicleModelById(v.Id);
        }
        return null;
    }
    public static Vehicle GetVehicleModel(this GTANetworkAPI.Vehicle  vehicle)
    {
        if (vehicle.HasData("vehicleModel"))
        {
            var v = vehicle.GetData<Vehicle>("vehicleModel");
            return v;
        }
        return null;
    }
    
    public static void SetVehicleIsRefueling(this GTANetworkAPI.Vehicle vehicle, bool toggle)
    {
        vehicle.SetData("isRefueling", toggle);
    }
    public static bool IsRefueling(this GTANetworkAPI.Vehicle  vehicle)
    {
        if (vehicle.HasData("isRefueling"))
        {
            return vehicle.GetData<bool>("isRefueling");
        }

        return false;
    }
}