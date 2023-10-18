
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
    public void OnBuyItem(Player player,int businessId, int idItem)
    {
        var business = BusinessHandler.GetBusinessById(businessId);
        if (business != null && business.BusinessType == BusinessesTypes.Market)
        {
            var item = business.Items.FirstOrDefault(i => i.ItemId == idItem);
            if (item.Count < 1)
            {
                player.SendNotify(NotifyType.Warning, "Данный товар закончился на складе");
                return;
            }
            if (player.MinusMoney(item.Price))
            {
                player.AddItem(ItemTypeHandler.GetItemByIdItem(idItem));
                if (business.OwnerCharacterId != 0)
                {
                    BusinessHandler.RemoveItem(item, business);
                    BusinessHandler.AddMoneyInBank(item.Price, business.Id);
                }
                StatisticBusinessHandler.AddBuyProduct(business);
            }
        }
    }

    [RemoteEvent("CEF::SERVER:BUY_FUEL")]
    public void OnBuyFuel(Player player, int businessId, int itemId, int count)
    {
        var business = BusinessHandler.GetBusinessById(businessId);
        if (business != null && business.BusinessType == BusinessesTypes.GasStation)
        {
            var item = business.Items.FirstOrDefault(i => i.ItemId == itemId);
            if (item.Count < 1)
            {
                player.SendNotify(NotifyType.Warning, "Это топливо закончилось");
                return;
            }
            if (player.Vehicle == null && player.VehicleSeat != (int)VehicleSeat.Driver)
            {
                player.SendNotify(NotifyType.Error, "Вы должны быть в машине");
                return;
            }
            if (player.MinusMoney(item.Price * count))
            {
                
            }
        }
    }
}