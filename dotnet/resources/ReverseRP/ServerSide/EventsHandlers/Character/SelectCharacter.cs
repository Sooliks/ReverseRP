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
            return;
        }
        player.ChangeCefWindow(CefWindowsPaths.CreateCharacter);
    }
}