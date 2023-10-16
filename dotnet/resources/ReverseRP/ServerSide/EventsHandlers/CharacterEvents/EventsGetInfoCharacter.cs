using GTANetworkAPI;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers;

public class EventsGetInfoCharacter : Script
{
    [RemoteProc("RPC::CEF::SERVER:GET_INFO_CHARACTER")]
    public string OnGetInfoCharacter(Player player)
    {
        var character = player.GetCharacter();
        return NAPI.Util.ToJson(new {money = character.Money, moneyBank = character.MoneyBank});
    }
}