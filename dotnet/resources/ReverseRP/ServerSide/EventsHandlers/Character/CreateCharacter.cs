using GTANetworkAPI;
using Newtonsoft.Json.Linq;
using ServerSide.Database.Handlers;
using ServerSide.Extensions;

namespace ServerSide.EventsHandlers;

public class CreateCharacter : Script
{
    [RemoteEvent("CEF::SERVER::ON_FINISH_CREATE_CHARACTER")]
    public async void OnFinishCreateCharacter(Player player, string characterJson)
    {
        NAPI.Util.ConsoleOutput(characterJson);
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
        string headOverlays = (string)character["headOverlays"];
        string headOverlaysColors = (string)character["headOverlaysColors"];
        string headBlendData = (string)character["blendData"];
        string faceFeatures = (string)character["faceFeatures"];
        CharacterHandler.AddNewCharacter(player.GetAccount(), firstName, lastName,birth,origin,headOverlays,headOverlaysColors,headBlendData,faceFeatures,gender);
    }
}