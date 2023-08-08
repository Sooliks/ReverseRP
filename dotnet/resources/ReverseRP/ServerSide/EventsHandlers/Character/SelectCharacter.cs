using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Extensions;
using ServerSide.Services;

namespace ServerSide.EventsHandlers;

public class SelectCharacter : Script
{
    [RemoteEvent("CEF::SERVER::ON_CLICK_CREATE_CHARACTER")]
    public async void OnClickCreateCharacter(Player player)
    {
        var account = player.GetAccount();
        if (CharacterHandler.GetCharactersByAccount(account).Count == 3)
        {
            NAPI.Util.ConsoleOutput("1");
            return;
        }
        player.ChangeCefWindow(CefWindowsPaths.CreateCharacter);
    }
    [RemoteEvent("CEF::SERVER::ON_SELECT_CHARACTER")]
    public async void OnClickSelectCharacter(Player player, int id)
    {
        if (CharacterHandler.IsAccountOwnerCharacter(player.GetAccount(), id))
        {
            player.ChangeCefWindow(CefWindowsPaths.Default);
            player.FreezePlayer(false);
            return;
        }
        return;
    }
    
}