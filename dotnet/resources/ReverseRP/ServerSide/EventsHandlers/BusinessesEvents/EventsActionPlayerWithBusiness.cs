using System;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Database.Models;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.BusinessesEvents;

public class EventsActionPlayerWithBusiness : Script
{
    [RemoteEvent("CEF::SERVER:ON_OPEN_BUSINESS_WINDOW")]
    public void OnOpenBusinessWindow(Player player, int businessId)
    {
        StatisticBusinessHandler.AddVisitor(BusinessHandler.GetBusinessById(businessId));
    }

    [RemoteEvent("CEF::SERVER:ON_GET_BANK")]
    public void OnGetBankBusiness(Player player, int businessId)
    {
        if (BusinessHandler.IsCharacterOwnerBusiness(player.GetCharacter(), businessId))
        {
            var business = BusinessHandler.GetBusinessById(businessId);
            BusinessHandler.MinusMoneyBank(business, business.Bank);
            player.PlusMoney(business.Bank);
        }
    }
}