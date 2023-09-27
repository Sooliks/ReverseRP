using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTANetworkAPI;
using Newtonsoft.Json;
using ServerSide.Database.Models;
using ServerSide.Entities;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.Inventory;

public class EventsInventory : Script
{
    [RemoteProc("RPC::CEF:SERVER:GetInventory")]
    public string GetInventory(Player player)
    {
        var inventory = player.GetInventory().Select(i => new
        {
            Id = i.Id, Count = i.Count, Name = i.Name, Description = i.Description, IdItem = i.IdItem, Hash = i.Hash, Type = i.GetType().Name
        }).ToList();
        Console.WriteLine(JsonConvert.SerializeObject(inventory));
        return JsonConvert.SerializeObject(inventory);
    }
}