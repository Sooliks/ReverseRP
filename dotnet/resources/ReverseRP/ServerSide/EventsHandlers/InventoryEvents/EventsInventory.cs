using System;
using System.Linq;
using GTANetworkAPI;
using Newtonsoft.Json;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.Inventory;

public class EventsInventory : Script
{
    [RemoteProc("RPC::CEF:SERVER:GetInventory")]
    public string GetInventory(Player player)
    {
        var inventory = player.GetInventory().Select(i => new
        {
            Id = i.Id, Count = i.Count, Name = i.Item.Name, Description = i.Item.Description, IdItem = i.Item.IdItem, Hash = i.Item.Hash, Type = i.GetType().Name
        }).ToList();
        Console.WriteLine(JsonConvert.SerializeObject(inventory));
        return JsonConvert.SerializeObject(inventory);
    }
}