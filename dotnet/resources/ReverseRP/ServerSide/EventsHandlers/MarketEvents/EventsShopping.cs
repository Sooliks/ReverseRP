using System;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Database.Models;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.MarketEvents;

public class EventsShopping : Script
{
    [RemoteEvent("CEF::SERVER:ON_BUY_ITEM")]
    public void OnBuyItem(Player player,int marketId, int idItem)
    {
        if (player.MinusMoney(120))
        {
            player.AddItem(new ItemBase(1, ItemHandler.GetItemByIdItem(idItem)));
        }
    }
}