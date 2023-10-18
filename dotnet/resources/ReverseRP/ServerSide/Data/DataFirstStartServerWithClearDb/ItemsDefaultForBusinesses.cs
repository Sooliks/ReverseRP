using System.Collections.Generic;
using ServerSide.Database.Models;
using ServerSide.Database.Models.GasStation;
using ServerSide.Enums;

namespace ServerSide.Data;

public class ItemsDefaultForBusinesses
{
    public static readonly List<MarketItem> DefaultItemsMarket = new List<MarketItem>()
    {
        new MarketItem(0, 100, 150)
    };
    public static readonly List<GasItem> DefaultItemsGasStation = new List<GasItem>()
    {
       new GasItem(GasType.Eco, 1000, 40),
       new GasItem(GasType.Premium, 1000, 50),
       new GasItem(GasType.Lux, 1000, 60),
       new GasItem(GasType.Electric, 1000, 27),
    };
}