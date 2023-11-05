

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

    
}