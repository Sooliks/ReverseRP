using System.Collections.Generic;
using GTANetworkAPI;
using ServerSide.Database.Models;
using ServerSide.Database.Models.GasStation;

namespace ServerSide.Data;

public class BusinessesData
{
    public static readonly List<BusinessBase> BusinessesDefault = new List<BusinessBase>()
    {
        new Market(1300000, ItemsDefaultForBusinesses.DefaultItemsMarket, new Vector3(23.983646,-1349.657,29.323343)),
        new GasStation(1300000, ItemsDefaultForBusinesses.DefaultItemsGasStation, new Vector3(-342.56717,-1475.105,30.748716))
    };
    
}