
using GTANetworkAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServerSide.Database.Handlers;
using ServerSide.Extensions;
using ServerSide.Services;
using ServerSide.Services.PlayerService;

namespace ServerSide.EventsHandlers;

public class EventsCreateCharacter : Script
{
    [RemoteEvent("CEF::SERVER::ON_FINISH_CREATE_CHARACTER")]
    public void OnFinishCreateCharacter(Player player, string characterJson)
    {
        var character = JObject.Parse(characterJson);
        bool gender = (string)character["gender"] == "женский" ? false : true;
        string firstName = (string)character["firstName"];
        string lastName = (string)character["lastName"];
        byte birth = (byte)character["birth"];
        int originId = (int)character["origin"];
        string origin = "";
        switch (originId)
        {
            case 1:
                origin = "Los Santos";
                break;
            case 2:
                origin = "Sandy Shores";
                break;
            case 3:
                origin = "Paleto Bay";
                break;
        }
        string headOverlays = JsonConvert.SerializeObject(character["headOverlays"]);
        string headOverlaysColors = JsonConvert.SerializeObject(character["headOverlaysColors"]);
        string headBlendData = JsonConvert.SerializeObject(character["blendData"]);
        string faceFeatures = JsonConvert.SerializeObject(character["faceFeatures"]);
        byte hairColor = (byte)character["hair"][1];
        int hairType = (int)character["hair"][0];
        byte eyeColor = (byte)character["eyeColor"];

        var playerAccount = player.GetAccount();
        CharacterHandler.AddNewCharacter(playerAccount,firstName, lastName, birth, origin, headOverlays, headOverlaysColors, headBlendData,
            faceFeatures, eyeColor, hairColor, hairType, gender);
        PlayerCustomization.PlayerSetBaseCustomization(player, headOverlays,headOverlaysColors,headBlendData,
            faceFeatures,gender, firstName, lastName, hairColor,hairType, eyeColor);
        player.SetCharacter(CharacterHandler.GetLastCharacterByAccount(playerAccount));
        player.ChangeCefWindow(CefWindowsPaths.Default);
        player.FreezePlayer(false);
        player.SetCameraOnPlayer(false);
    }
}