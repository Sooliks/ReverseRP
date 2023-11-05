

using GTANetworkAPI;
using ServerSide.Database.Handlers;
using Utils;

namespace ServerSide.Services.VehicleServices;

public class VehicleService
{
    public static string GetUniqNumberPlate()
    {
        var numberPlate = StringGenerator.GenerateUpperCaseString(7);
        if (VehicleHandler.IsNumberPlateExist(numberPlate))
        {
            GetUniqNumberPlate();
        }
        return numberPlate;
    }

    public static void CreateVehicle(Vehicle vehicle,Vector3 position, float heading)
    {
        vehicle.Spawn(position, heading);
    }
}