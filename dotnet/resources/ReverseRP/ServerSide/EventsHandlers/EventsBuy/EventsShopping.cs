
using System.Linq;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Enums;
using ServerSide.Extensions;


namespace ServerSide.EventsHandlers.MarketEvents;

public class EventsShopping : Script
{
    [RemoteEvent("CEF::SERVER:ON_BUY_ITEM")]
    public void OnBuyItem(Player player,int marketId, int idItem, int itemType)
    {
        var market = MarketsHandler.GetMarketByIdMarket(marketId);
        if (market != null)
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
                if (market.OwnerCharacter != null)
                {
                    MarketsHandler.RemoveItem(item, market);
                    BusinessHandler.AddMoneyInBank(item.Price, market.Id);
                }
                StatisticBusinessHandler.AddVisitor(market);
            }
        }
    }
}