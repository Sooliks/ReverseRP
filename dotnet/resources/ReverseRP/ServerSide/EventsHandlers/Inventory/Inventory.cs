using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTANetworkAPI;
using Newtonsoft.Json;
using ServerSide.Database.Models;
using ServerSide.Entities;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.Inventory;

public class Inventory : Script
{
    [RemoteProc("RPC::CEF:SERVER:GetInventory")]
    public string GetInventory(Player player)
    {
        var list = NAPI.Util.ToJson(player.GetCharacter().Inventory);
        /*return JsonConvert.SerializeObject(list, Formatting.Indented,
            new JsonSerializerSettings() {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }
        );*/
        NAPI.Util.ConsoleOutput(list);
        return list;
    }
}