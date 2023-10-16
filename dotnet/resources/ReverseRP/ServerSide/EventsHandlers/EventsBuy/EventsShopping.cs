
using System;
using System.Linq;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Database.Models;
using ServerSide.Enums;
using ServerSide.Extensions;


namespace ServerSide.EventsHandlers.EventsBuy;

public class EventsShopping : Script
{
    [RemoteEvent("CEF::SERVER:ON_BUY_ITEM")]
    public void OnBuyItem(Player player,int businessId, int idItem, int itemType)
    {
        var business = BusinessHandler.GetBusinessById(businessId);
        if (business != null && business is Market market)
        {
            var item = market.Items.FirstOrDefault(i => i.IdItem == idItem);
            if (item.Count < 1)
            {
                player.SendNotify(NotifyType.Warning, "Данный товар закончился на складе");
                return;
            }
            if (player.MinusMoney(item.Price))
            {
                player.AddItem(ItemTypeHandler.GetItemByIdItem(idItem));
                if (market.OwnerCharacterId != 0)
                {
                    MarketsHandler.RemoveItem(item, market);
                    BusinessHandler.AddMoneyInBank(item.Price, market.Id);
                }
                StatisticBusinessHandler.AddBuyProduct(market);
            }
        }
    }
}