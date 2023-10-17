using GTANetworkAPI;

namespace ServerSide.Database.Models.GasStation;

public class GasStation : BusinessBase
{
    public int GasStationId { get; set; }
    public int CountGas { get; set; }

    public GasStation()
    {
        
    }

    public GasStation(int gasStationId,int gosPrice, Vector3 positionManagementBusiness): base(gosPrice,positionManagementBusiness)
    {
        GasStationId = gasStationId;
        CountGas = 1000;
    }
}