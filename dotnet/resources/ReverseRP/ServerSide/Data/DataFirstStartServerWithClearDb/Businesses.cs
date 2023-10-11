using System.Collections.Generic;
using GTANetworkAPI;
using ServerSide.Database.Models;

namespace ServerSide.Data;

public class Businesses
{
    public static readonly List<BusinessBase> BusinessesDefault = new List<BusinessBase>()
    {
        new Market(1, 1300000, ItemsDefaultMarket.DefaultItemsMarket, new Vector3(23.983646,-1349.657,29.323343))
    };
}