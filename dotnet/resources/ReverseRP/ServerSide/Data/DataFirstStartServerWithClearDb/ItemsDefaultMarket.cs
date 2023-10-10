using System.Collections.Generic;
using ServerSide.Database.Models;

namespace ServerSide.Data;

public class ItemsDefaultMarket
{
    public static readonly List<MarketItem> DefaultItemsMarket = new List<MarketItem>()
    {
        new MarketItem(0, 100, 150)
    };
}