using System;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Database.Models;
using ServerSide.Enums;

namespace ServerSide.EventsHandlers.BusinessesEvents;

public class EventsGetBusinessInfo : Script
{
    [RemoteProc("RPC::CEF::SERVER:GetProductsMarket")]
    public string OnGetProductsMarket(Player player, int businessId)
    {
        var business = BusinessHandler.GetBusinessById(businessId);
        if (business.BusinessType != BusinessesTypes.Market) return "null";
        return NAPI.Util.ToJson(business.Items);
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
        var character = CharacterHandler.GetCharacterById(business.OwnerCharacterId);
        return NAPI.Util.ToJson(new
        {
            OwnerName = business.OwnerCharacterId!=0 ? $"{character.FirstName} {character.LastName}" : "Нету",
            GosPrice = business.GosPrice,
            Type = business.BusinessType
        });
    }


    [RemoteProc("RPC::CEF::SERVER:GetProductsBusiness")]
    public string OnGetProductsBusiness(Player player, int businessId)
    {
        var business = BusinessHandler.GetBusinessById(businessId);
        return NAPI.Util.ToJson(business.Items);
    }
}