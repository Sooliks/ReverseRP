using System.Collections.Generic;
using ServerSide.Database.Models;

namespace ServerSide.Data;

public class Businesses
{
    public static readonly List<BusinessBase> BusinessesDefault = new List<BusinessBase>()
    {
        new Market(1, 1300000, ItemsDefaultMarket.DefaultItemsMarket)
    };
}