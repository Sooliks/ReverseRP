using GTANetworkAPI;

namespace ServerSide.EventsHandlers.BusinessesEvents;

public class EventsCarDealerShip
{
    [RemoteEvent("CEF::SERVER:SELECT_CAR")]
    public void OnSelectCar(Player player, int businessId, int carId)
    {
        
    }
}