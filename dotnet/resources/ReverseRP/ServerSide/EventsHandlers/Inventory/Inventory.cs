using System.Collections.Generic;
using System.Threading.Tasks;
using GTANetworkAPI;
using ServerSide.Database.Models;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers.Inventory;

public class Inventory : Script
{
    [RemoteProc("RPC::CEF:SERVER:GetInventory")]
    public string GetInventory(Player player)
    {
        var res = NAPI.Util.ToJson(player.GetCharacter().Inventory);
        return res;
    }
}