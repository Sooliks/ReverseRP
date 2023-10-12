using System;
using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Database.Models;

namespace ServerSide.EventsHandlers.BusinessesEvents;

public class EventsActionPlayerWithBusiness : Script
{
    [RemoteEvent("CEF::SERVER:ON_OPEN_BUSINESS_WINDOW")]
    public void OnOpenBusinessWindow(Player player, int businessId)
    {
        StatisticBusinessHandler.AddVisitor(BusinessHandler.GetBusinessById(businessId));
    }
}