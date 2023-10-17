using System;
using GTANetworkAPI;
using ServerSide.Extensions;

namespace ServerSide.Services.MapService;

public class InputMarker : Script
{
    private static readonly string ColShapeCefPathKey = nameof(ColShapeCefPathKey);
    private static readonly string ColShapeGetCallbackKey = nameof(ColShapeGetCallbackKey);
    private static readonly string ColshapeIsAllowInVehicleKey = nameof(ColshapeIsAllowInVehicleKey);
    
    /// <summary>
    /// Дефолтный маркер, с колшейпом блипом, маркером и с открытием cef path
    /// </summary>
    /// <param name="textLabel"></param>
    /// <param name="pos"></param>
    /// <param name="iconBlip"></param>
    /// <param name="colorBlip"></param>
    /// <param name="nameCefPath"></param>
    public static void CreateDefaultInputMarkerWithOpenCefPath(string textLabel, Vector3 pos, int iconBlip, byte colorBlip, string nameCefPath, bool allowInVehicle = false)
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
        colShape.SetData(ColshapeIsAllowInVehicleKey,allowInVehicle);
    }
    
    /// <summary>
    /// Дефолтный маркер, с колшейпом, маркером без блипа и с открытием cef path
    /// </summary>
    /// <param name="textLabel"></param>
    /// <param name="pos"></param>
    /// <param name="iconBlip"></param>
    /// <param name="colorBlip"></param>
    /// <param name="nameCefPath"></param>
    public static void CreateInputMarkerWithOpenCefPathWithoutBlip(string textLabel, Vector3 pos, string nameCefPath, bool allowInVehicle = false)
    {
        float posX = pos.X;
        float posY = pos.Y;
        float posZ = pos.Z;
        NAPI.TextLabel.CreateTextLabel(textLabel, new Vector3(posX, posY, posZ + 0.8f), 20.0f, 0.75f, 4, new Color(255, 255, 255));//Основной тект
        NAPI.Marker.CreateMarker(MarkerType.VerticalCylinder, new Vector3(posX, posY, posZ - 1), new Vector3(), new Vector3(), 1.0f, new Color(255, 255, 255));//Маркер
        var colShape = NAPI.ColShape.CreateCylinderColShape(pos, 1.0f, 1.0f);
        colShape.SetData(ColShapeCefPathKey,nameCefPath);
        colShape.SetData(ColshapeIsAllowInVehicleKey,allowInVehicle);
    }
    /// <summary>
    /// Дефолтный маркер, с колшейпом, маркером, блипом и с функцией обратного вызова
    /// </summary>
    /// <param name="textLabel"></param>
    /// <param name="pos"></param>
    /// <param name="iconBlip"></param>
    /// <param name="colorBlip"></param>
    /// <param name="nameCefPath"></param>
    public static void CreateDefaultInputMarkerWithFuncCallback(string textLabel, Vector3 pos, int iconBlip, byte colorBlip, Callback callback, bool allowInVehicle = false)
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
        colShape.SetData(ColShapeGetCallbackKey,callback);
        colShape.SetData(ColshapeIsAllowInVehicleKey,allowInVehicle);
    }
    /// <summary>
    /// Дефолтный маркер, с колшейпом, маркером, без блипа и с функцией обратного вызова
    /// </summary>
    /// <param name="textLabel"></param>
    /// <param name="pos"></param>
    /// <param name="iconBlip"></param>
    /// <param name="colorBlip"></param>
    /// <param name="nameCefPath"></param>
    public static void CreateDefaultInputMarkerWithFuncCallbackWithoutBlip(string textLabel, Vector3 pos, Callback callback, bool allowInVehicle = false)
    {
        float posX = pos.X;
        float posY = pos.Y;
        float posZ = pos.Z;
        NAPI.TextLabel.CreateTextLabel(textLabel, new Vector3(posX, posY, posZ + 0.8f), 20.0f, 0.75f, 4, new Color(255, 255, 255));//Основной тект
        NAPI.Marker.CreateMarker(MarkerType.VerticalCylinder, new Vector3(posX, posY, posZ - 1), new Vector3(), new Vector3(), 1.0f, new Color(255, 255, 255));//Маркер
        var colShape = NAPI.ColShape.CreateCylinderColShape(pos, 1.0f, 1.0f);
        colShape.SetData(ColShapeGetCallbackKey,callback);
        colShape.SetData(ColshapeIsAllowInVehicleKey,allowInVehicle);
    }

    public static void CreateColShapeWithOpenCefPath(Vector3 pos, float range, string nameCefPath, bool allowInVehicle = false)
    {
        var colShape = NAPI.ColShape.CreateCylinderColShape(pos, range, 1.0f);
        colShape.SetData(ColShapeCefPathKey,nameCefPath);
        colShape.SetData(ColshapeIsAllowInVehicleKey,allowInVehicle);
    }
    public delegate void Callback(Player player);

    [ServerEvent(Event.PlayerEnterColshape)]
    public static void OnPlayerEnterColShape(ColShape colShape, Player player)
    {
        bool allowInVehicle = colShape.HasData(ColshapeIsAllowInVehicleKey) ? colShape.GetData<bool>(ColshapeIsAllowInVehicleKey) : false;
        
        if (colShape.HasData(ColShapeCefPathKey))
        {
            if (!allowInVehicle)
            {
                if(player.IsInVehicle)return;
            }
            player.ChangeCefWindow(colShape.GetData<string>(ColShapeCefPathKey));
        }
        if (colShape.HasData(ColShapeGetCallbackKey))
        {
            if (!allowInVehicle)
            {
                if(player.IsInVehicle)return;
            }
            colShape.GetData<Callback>(ColShapeGetCallbackKey)(player);
        }
    }
    
}