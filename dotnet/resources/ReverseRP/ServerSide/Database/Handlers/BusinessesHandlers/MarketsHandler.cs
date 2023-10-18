using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ServerSide.Database.Models;

namespace ServerSide.Database.Handlers;

public class MarketsHandler
{
    public static void RemoveItem(MarketItem marketItem, Market market, int count = 1)
    {
        using Context db = new Context();
        var newListItems = market.Items;
        int index = market.Items.FindIndex(s => s.IdItem == marketItem.IdItem);
        marketItem.Count -= count;
        newListItems[index] = marketItem;
        market.Items = newListItems;
        db.BusinessesBase.Update(market);
        db.SaveChanges();
    }
}