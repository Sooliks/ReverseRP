using System;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Database.Models;

namespace ServerSide.EventsHandlers.BusinessesEvents;

public class EventsGetBusinessInfo : Script
{
    [RemoteProc("RPC::CEF::SERVER:GetProductsMarket")]
    public string OnGetProductsMarket(Player player, int businessId)
    {
        if (BusinessHandler.GetBusinessById(businessId) is Market market)
        {
            return NAPI.Util.ToJson(market.Items);
        }

        return null;
    }
    [RemoteProc("RPC::CEF::SERVER:GetStatisticsBusiness")]
    public string OnGetStatisticsBusiness(Player player, int businessId)
    {
        return NAPI.Util.ToJson(StatisticBusinessHandler.GetCountVisitorsAllDays(BusinessHandler.GetBusinessById(businessId)));
    }

    [RemoteProc("RPC::CEF::SERVER:GetExtendedStatistic")]
    public string OnGetExtendStatistic(Player player, int businessId)
    {
        var business = BusinessHandler.GetBusinessById(businessId);
        return NAPI.Util.ToJson(new
        {
            CountVisitorsCurrentDay = StatisticBusinessHandler.GetCountVisitorsCurrentDay(business),
            Bank = business.Bank,
            CountVisitorsMonth = StatisticBusinessHandler.GetCountVisitorsMonth(business)
        });
    }

    [RemoteProc("RPC::CEF::SERVER:GetInformationBusiness")]
    public string OnGetInformationBusiness(Player player, int businessId)
    {
        var business = BusinessHandler.GetBusinessById(businessId);
        return NAPI.Util.ToJson(new
        {
            OwnerName = business.OwnerCharacter!=null ? $"{business.OwnerCharacter.FirstName} {business.OwnerCharacter.LastName}" : "Нету",
            GosPrice = business.GosPrice,
            Type = business.GetType().Name
        });
    }
}