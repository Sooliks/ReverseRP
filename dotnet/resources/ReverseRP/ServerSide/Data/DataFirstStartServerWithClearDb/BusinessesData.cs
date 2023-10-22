using System.Collections.Generic;
using GTANetworkAPI;
using ServerSide.Database.Models;
using ServerSide.Enums;


namespace ServerSide.Data;

public class BusinessesData
{
    public static readonly List<BusinessBase> BusinessesDefault = new List<BusinessBase>()
    {
        new BusinessBase(1300000, new Vector3(23.983646,-1349.657,29.323343), ItemsDefaultForBusinesses.DefaultItemsMarket, BusinessesTypes.Market),
        new BusinessBase(1300000, new Vector3(-342.56717,-1475.105,30.748716), ItemsDefaultForBusinesses.DefaultItemsGasStation, BusinessesTypes.GasStation),
        new BusinessBase(1500000, new Vector3(-805.5731,-219.66866,37.264988), ItemsDefaultForBusinesses.DefaultItemsCarDealerShipLuxury, BusinessesTypes.CarDealerShipLuxury)
    };
    
}