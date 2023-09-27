using GTANetworkAPI;
using ServerSide.Extensions;

namespace ServerSide.Services.MapService;

public class InputMarker : Script
{
    private static readonly string ColShapeCefPathKey = nameof(ColShapeCefPathKey);
    public static void CreateDefaultInputMarkerWithOpenCefPath(string textLabel, Vector3 pos, int iconBlip, byte colorBlip, string nameCefPath)
    {
        float posX = pos.X;
        float posY = pos.Y;
        float posZ = pos.Z;
        NAPI.TextLabel.CreateTextLabel(textLabel, new Vector3(posX, posY, posZ + 0.8f), 20.0f, 0.75f, 4, new Color(255, 255, 255));//Основной тект
        NAPI.Marker.CreateMarker(MarkerType.VerticalCylinder, new Vector3(posX, posY, posZ - 1), new Vector3(), new Vector3(), 1.0f, new Color(255, 255, 255));//Маркер
        Blip blip = NAPI.Blip.CreateBlip(iconBlip, new Vector3(posX, posY, posZ), 1.0f, colorBlip);//Блип
        NAPI.Blip.SetBlipName(blip, textLabel);//Установка имени блипу
        NAPI.Blip.SetBlipShortRange(blip, true); //Установка видимости блипу
        var colShape = NAPI.ColShape.CreateCylinderColShape(pos, 1.0f, 1.0f);
        colShape.SetData(ColShapeCefPathKey,nameCefPath);
    }

    [ServerEvent(Event.PlayerEnterColshape)]
    public static void OnPlayerEnterColShape(ColShape colShape, Player player)
    {
        if (colShape.HasData(ColShapeCefPathKey))
        {
            if(player.IsInVehicle)return;
            player.ChangeCefWindow(colShape.GetData<string>(ColShapeCefPathKey));
        }
    }
    
}