using System.Collections.Generic;
using ServerSide.Database.Models;
using ServerSide.Enums;

namespace ServerSide.Data;

public class ItemsDefaultForBusinesses
{
    public static readonly List<ItemBusiness> DefaultItemsMarket = new List<ItemBusiness>()
    {
        new ItemBusiness(0, 100, 150)
    };
    public static readonly List<ItemBusiness> DefaultItemsGasStation = new List<ItemBusiness>()
    {
       new ItemBusiness((int)GasType.Eco, 1000, 40),
       new ItemBusiness((int)GasType.Premium, 1000, 50),
       new ItemBusiness((int)GasType.Lux, 1000, 60),
       new ItemBusiness((int)GasType.Electric, 1000, 27),
    };
    public static readonly List<ItemBusiness> DefaultItemsCarDealerShipLuxury = new List<ItemBusiness>()
    {
        new ItemBusiness(1, 10,2000000),
        new ItemBusiness(2, 10,2100000),
        new ItemBusiness(3, 10,2200000),
    };
}