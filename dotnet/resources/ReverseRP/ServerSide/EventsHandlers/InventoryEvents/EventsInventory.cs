using System;
using System.Linq;
using GTANetworkAPI;
using Newtonsoft.Json;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.Inventory;

public class EventsInventory : Script
{
    [RemoteProc("RPC::CEF:SERVER:GetInventoryPlayer")]
    public string GetInventory(Player player)
    {
        var inventory = player.GetInventory().Select(i => new
        {
            count = i.Count, name = i.Item.Name, description = i.Item.Description, idItem = i.Item.IdItem, hash = i.Item.Hash, type = i.GetType().Name
        }).ToList();
        return JsonConvert.SerializeObject(inventory);
    }
}