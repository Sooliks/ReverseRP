using ServerSide.Database.Handlers;
using ServerSide.Database.Models;
using ServerSide.Enums;

namespace ServerSide.Services.BusinessesServices;

public class BusinessService
{
    public static string GetNameBusinessItemByItemId(BusinessBase businessBase, int itemId)
    {
        switch (businessBase.BusinessType)
        {
            case BusinessesTypes.Market:
                return ItemTypeHandler.GetItemByIdItem(itemId).Name;
            case BusinessesTypes.GasStation:
                var enumDisplayStatus = (GasType)itemId;
                return enumDisplayStatus.ToString();
            case BusinessesTypes.CarDealerShipLuxury:
                var vehicle = VehicleTypeHandler.GetVehicleTypeById(itemId);
                return vehicle.Mark + " " + vehicle.Model;
            default:
                return null;
        }
    }
}