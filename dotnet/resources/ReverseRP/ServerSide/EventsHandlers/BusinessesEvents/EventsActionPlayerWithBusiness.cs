using System;
using GTANetworkAPI;
using Microsoft.EntityFrameworkCore.Query;
using ServerSide.Database.Handlers;
using ServerSide.Database.Handlers.BusinessesHandlers;
using ServerSide.Database.Models;
using ServerSide.Extensions;
using ServerSide.Services.BusinessesServices;

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
        var business = BusinessHandler.GetBusinessById(businessId);
        if (BusinessHandler.IsCharacterOwnerBusiness(player.GetCharacter(), business))
        {
            player.PlusMoney(business.Bank);
            BusinessHandler.MinusMoneyBank(business, business.Bank);
        }
    }

    [RemoteEvent("CEF::SERVER:ChangePriceItem")]
    public void ChangePriceItem(Player player, int businessId, int businessItemId, int newPrice)
    {
        if(!player.IsAuthorized())return;
        var business = BusinessHandler.GetBusinessById(businessId);
        if (BusinessHandler.IsCharacterOwnerBusiness(player.GetCharacter(), business))
        {
            BusinessHandler.ChangePriceItem(business, businessItemId, newPrice);
        }
    }

    [RemoteEvent("CEF::SERVER:OrderItem")]
    public void OnOrderItem(Player player, int businessId, int businessItemId, int count)
    {
        if(!player.IsAuthorized())return;
        var business = BusinessHandler.GetBusinessById(businessId);
        if (BusinessHandler.IsCharacterOwnerBusiness(player.GetCharacter(), business))
        {
            BusinessHandler.AddOrder(business, businessItemId, count, BusinessService.GetNameBusinessItemByItemId(business, businessItemId));
        }
    }
}