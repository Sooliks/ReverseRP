using GTANetworkAPI;
using ServerSide.Database.Handlers;
using ServerSide.Entities;
using ServerSide.Enums;
using ServerSide.Extensions;
using ServerSide.Services;
using ServerSide.Services.PlayerService;

namespace ServerSide.EventsHandlers;

public class EventsSelectCharacter : Script
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
        //TODO сделать
        player.SetCameraOnPlayer(true);
    }
    [RemoteEvent("CEF::SERVER::ON_SELECT_CHARACTER")]
    public async void OnClickSelectCharacter(Player player, int id)
    {
        if (CharacterHandler.IsAccountOwnerCharacter(player.GetAccount(), id))
        {
            var character = CharacterHandler.GetCharacterById(id);
            player.SetCharacter(character);
            PlayerCustomization.PlayerSetBaseCustomization(player,character.HeadOverlaysJson,
                character.HeadOverlaysColorsJson, character.HeadBlendDataJson,
                character.FaceFeaturesJson, character.Gender, character.FirstName, character.LastName,
                character.HairColor, character.HairType, character.EyeColor);
            player.ChangeCefWindow(CefWindowsPaths.Default);
            player.FreezePlayer(false);
        }
    }
    
}