using System;
using GTANetworkAPI;
using ServerSide.Enums;
using ServerSide.Extensions;

namespace ServerSide.Services.MapService;

public class InputMarker : Script
{
    private static readonly string ColShapeCefPathKey = nameof(ColShapeCefPathKey);
    private static readonly string ColShapeGetCallbackKey = nameof(ColShapeGetCallbackKey);
    private static readonly string ColshapeIsForWalkingKey = nameof(ColshapeIsForWalkingKey);
    private static readonly string ColShapeIsTriggeredByPressEKey = nameof(ColShapeIsTriggeredByPressEKey);
    public static readonly string ActiveColshapePlayerKey = nameof(ActiveColshapePlayerKey);
    
    /// <summary>
    /// Дефолтный маркер, с колшейпом блипом, маркером и с открытием cef path
    /// </summary>
    /// <param name="textLabel"></param>
    /// <param name="pos"></param>
    /// <param name="iconBlip"></param>
    /// <param name="colorBlip"></param>
    /// <param name="nameCefPath"></param>
    public static void CreateDefaultInputMarkerWithOpenCefPath(string textLabel, Vector3 pos, int iconBlip, byte colorBlip, string nameCefPath, bool isForWalking = true, uint dimension = 0)
    {
        float posX = pos.X;
        float posY = pos.Y;
        float posZ = pos.Z;
        NAPI.TextLabel.CreateTextLabel(textLabel, new Vector3(posX, posY, posZ + 0.8f), 20.0f, 0.75f, 4, new Color(255, 255, 255), dimension:dimension);//Основной тект
        NAPI.Marker.CreateMarker(MarkerType.VerticalCylinder, new Vector3(posX, posY, posZ - 1), new Vector3(), new Vector3(), 1.0f, new Color(255, 255, 255), dimension:dimension);//Маркер
        Blip blip = NAPI.Blip.CreateBlip(iconBlip, new Vector3(posX, posY, posZ), 1.0f, colorBlip, dimension:dimension);//Блип
        NAPI.Blip.SetBlipName(blip, textLabel);//Установка имени блипу
        NAPI.Blip.SetBlipShortRange(blip, true); //Установка видимости блипу
        var colShape = NAPI.ColShape.CreateCylinderColShape(pos, 1.0f, 1.0f, dimension:dimension);
        colShape.SetData(ColShapeCefPathKey,nameCefPath);
        colShape.SetData(ColshapeIsForWalkingKey,isForWalking);
    }
    
    /// <summary>
    /// Дефолтный маркер, с колшейпом, маркером без блипа и с открытием cef path
    /// </summary>
    /// <param name="textLabel"></param>
    /// <param name="pos"></param>
    /// <param name="iconBlip"></param>
    /// <param name="colorBlip"></param>
    /// <param name="nameCefPath"></param>
    public static void CreateInputMarkerWithOpenCefPathWithoutBlip(string textLabel, Vector3 pos, string nameCefPath, bool isForWalking = true, uint dimension = 0)
    {
        float posX = pos.X;
        float posY = pos.Y;
        float posZ = pos.Z;
        NAPI.TextLabel.CreateTextLabel(textLabel, new Vector3(posX, posY, posZ + 0.8f), 20.0f, 0.75f, 4, new Color(255, 255, 255), dimension:dimension);//Основной тект
        NAPI.Marker.CreateMarker(MarkerType.VerticalCylinder, new Vector3(posX, posY, posZ - 1), new Vector3(), new Vector3(), 1.0f, new Color(255, 255, 255), dimension:dimension);//Маркер
        var colShape = NAPI.ColShape.CreateCylinderColShape(pos, 1.0f, 1.0f, dimension:dimension);
        colShape.SetData(ColShapeCefPathKey,nameCefPath);
        colShape.SetData(ColshapeIsForWalkingKey,isForWalking);
    }
    /// <summary>
    /// Дефолтный маркер, с колшейпом, маркером, блипом и с функцией обратного вызова
    /// </summary>
    /// <param name="textLabel"></param>
    /// <param name="pos"></param>
    /// <param name="iconBlip"></param>
    /// <param name="colorBlip"></param>
    /// <param name="nameCefPath"></param>
    public static void CreateDefaultInputMarkerWithFuncCallback(string textLabel, Vector3 pos, int iconBlip, byte colorBlip, Callback callback, bool isForWalking = true, uint dimension = 0)
    {
        float posX = pos.X;
        float posY = pos.Y;
        float posZ = pos.Z;
        NAPI.TextLabel.CreateTextLabel(textLabel, new Vector3(posX, posY, posZ + 0.8f), 20.0f, 0.75f, 4, new Color(255, 255, 255), dimension:dimension);//Основной тект
        NAPI.Marker.CreateMarker(MarkerType.VerticalCylinder, new Vector3(posX, posY, posZ - 1), new Vector3(), new Vector3(), 1.0f, new Color(255, 255, 255), dimension:dimension);//Маркер
        Blip blip = NAPI.Blip.CreateBlip(iconBlip, new Vector3(posX, posY, posZ), 1.0f, colorBlip, dimension:dimension);//Блип
        NAPI.Blip.SetBlipName(blip, textLabel);//Установка имени блипу
        NAPI.Blip.SetBlipShortRange(blip, true); //Установка видимости блипу
        var colShape = NAPI.ColShape.CreateCylinderColShape(pos, 1.0f, 1.0f, dimension:dimension);
        colShape.SetData(ColShapeGetCallbackKey,callback);
        colShape.SetData(ColshapeIsForWalkingKey,isForWalking);
    }
    /// <summary>
    /// Дефолтный маркер, с колшейпом, маркером, без блипа и с функцией обратного вызова
    /// </summary>
    /// <param name="textLabel"></param>
    /// <param name="pos"></param>
    /// <param name="iconBlip"></param>
    /// <param name="colorBlip"></param>
    /// <param name="nameCefPath"></param>
    public static void CreateDefaultInputMarkerWithFuncCallbackWithoutBlip(string textLabel, Vector3 pos, Callback callback, bool isForWalking = true, uint dimension = 0)
    {
        float posX = pos.X;
        float posY = pos.Y;
        float posZ = pos.Z;
        NAPI.TextLabel.CreateTextLabel(textLabel, new Vector3(posX, posY, posZ + 0.8f), 20.0f, 0.75f, 4, new Color(255, 255, 255), dimension:dimension);//Основной тект
        NAPI.Marker.CreateMarker(MarkerType.VerticalCylinder, new Vector3(posX, posY, posZ - 1), new Vector3(), new Vector3(), 1.0f, new Color(255, 255, 255), dimension:dimension);//Маркер
        var colShape = NAPI.ColShape.CreateCylinderColShape(pos, 1.0f, 1.0f, dimension:dimension);
        colShape.SetData(ColShapeGetCallbackKey,callback);
        colShape.SetData(ColshapeIsForWalkingKey,isForWalking);
    }
    /// <summary>
    /// Колшейп с открытием cefpath
    /// </summary>
    /// <param name="pos">позиция колшейпа</param>
    /// <param name="range">радиус колшейпа</param>
    /// <param name="nameCefPath">сefPath for open</param>
    /// <param name="isForWalking">для ходьбы на колшейп либо для машины</param>
    public static void CreateColShapeWithOpenCefPath(Vector3 pos, float range, string nameCefPath, bool isForWalking = true, uint dimension = 0)
    {
        var colShape = NAPI.ColShape.CreateCylinderColShape(pos, range, 1.0f, dimension:dimension);
        colShape.SetData(ColShapeCefPathKey,nameCefPath);
        colShape.SetData(ColshapeIsForWalkingKey,isForWalking);
    }
    /// <summary>
    /// Колшейп с callback
    /// </summary>
    /// <param name="pos">позиция колшейпа</param>
    /// <param name="range">радиус колшейпа</param>
    /// <param name="callback">функция обратного вызова при срабатывании колшейпа</param>
    /// <param name="isForWalking">для ходьбы на колшейп либо для машины</param>
    public static void CreateColShapeWithCallback(Vector3 pos, float range, Callback callback, bool isForWalking = true, bool isTriggeredByPressKey = false, uint dimension = 0)
    {
        var colShape = NAPI.ColShape.CreateCylinderColShape(pos, range, 1.0f, dimension:dimension);
        if (isTriggeredByPressKey)
        {
            colShape.SetData(ColShapeIsTriggeredByPressEKey,isTriggeredByPressKey);
        }
        colShape.SetData(ColShapeGetCallbackKey,callback);
        colShape.SetData(ColshapeIsForWalkingKey,isForWalking);
    }
    public static void CreateNpcWithOpenCefPath(string namePed, Vector3 position, float heading, string titlePed, string titleBlip, int iconBlip, byte colorBlip, string nameCefPath, uint dimension = 0)
    {
        var ped = NAPI.Ped.CreatePed(NAPI.Util.GetHashKey(namePed), position, heading, false, false, true, true, dimension);
        var colShape = NAPI.ColShape.CreateCylinderColShape(position, 1.0f, 1.0f, dimension:dimension);
        Blip blip = NAPI.Blip.CreateBlip(iconBlip, position, 1.0f, colorBlip, dimension:dimension);
        NAPI.Blip.SetBlipName(blip, titleBlip);
        NAPI.Blip.SetBlipShortRange(blip, true);
        colShape.SetData(ColShapeIsTriggeredByPressEKey,true);
        colShape.SetData(ColshapeIsForWalkingKey,true);
        colShape.SetData(ColShapeCefPathKey,nameCefPath);
    }
    public static void CreateNpcWithCallback(string namePed, Vector3 position, float heading, string titlePed, string titleBlip, int iconBlip, byte colorBlip, Callback callback, uint dimension = 0)
    {
        var ped = NAPI.Ped.CreatePed(NAPI.Util.GetHashKey(namePed), position, heading, false, false, true, true, dimension);
        var colShape = NAPI.ColShape.CreateCylinderColShape(position, 1.0f, 1.0f, dimension:dimension);
        Blip blip = NAPI.Blip.CreateBlip(iconBlip, position, 1.0f, colorBlip, dimension:dimension);
        NAPI.Blip.SetBlipName(blip, titleBlip);
        NAPI.Blip.SetBlipShortRange(blip, true);
        colShape.SetData(ColShapeIsTriggeredByPressEKey,true);
        colShape.SetData(ColshapeIsForWalkingKey,true);
        colShape.SetData(ColShapeGetCallbackKey,callback);
    }
    
    public delegate void Callback(Player player);

    [ServerEvent(Event.PlayerEnterColshape)]
    public static void OnPlayerEnterColShape(ColShape colShape, Player player)
    {
        bool isForWalking = colShape.HasData(ColshapeIsForWalkingKey) ? colShape.GetData<bool>(ColshapeIsForWalkingKey) : false;
        if (colShape.HasData(ColShapeIsTriggeredByPressEKey))
        {
            if (isForWalking)
            {
                if(player.IsInVehicle)return;
                player.SendNotify(NotifyType.Info, "Нажмите Е");
            }
            else
            {
                if(player.Vehicle == null)return;
                if(player.VehicleSeat != (int)VehicleSeat.Driver)return;
                player.SendNotify(NotifyType.Info, "Нажмите Е");
            }
            player.SetData(ActiveColshapePlayerKey, colShape);
            return;
        }
        
        if (colShape.HasData(ColShapeCefPathKey))
        {
            if (isForWalking)
            {
                if(player.IsInVehicle)return;
                player.ChangeCefWindow(colShape.GetData<string>(ColShapeCefPathKey));
            }
            else
            {
                if(player.Vehicle == null)return;
                player.ChangeCefWindow(colShape.GetData<string>(ColShapeCefPathKey));
            }
        }
        if (colShape.HasData(ColShapeGetCallbackKey))
        {
            if (isForWalking)
            {
                if(player.IsInVehicle)return;
                colShape.GetData<Callback>(ColShapeGetCallbackKey)(player);
            }
            else
            {
                if(player.Vehicle == null)return;
                colShape.GetData<Callback>(ColShapeGetCallbackKey)(player);
            }
        }
    }

    [ServerEvent(Event.PlayerExitColshape)]
    public static void OnPlayerExitColShape(ColShape colShape, Player player)
    {
        //player.ChangeCefWindow(CefWindowsPaths.Default);
        player.ResetData(ActiveColshapePlayerKey);
    }

    [RemoteEvent("CLIENT::SERVER:PRESS_E")]
    public void OnPressE(Player player)
    {
        if (player.HasData(ActiveColshapePlayerKey))
        {
            var colShape = player.GetData<ColShape>(ActiveColshapePlayerKey);
            bool isForWalking = colShape.HasData(ColshapeIsForWalkingKey) ? colShape.GetData<bool>(ColshapeIsForWalkingKey) : false;
            if (isForWalking)
            {
                if (colShape.HasData(ColShapeCefPathKey))
                {
                    if (player.IsInVehicle) return;
                    player.ChangeCefWindow(colShape.GetData<string>(ColShapeCefPathKey));
                }
                if (colShape.HasData(ColShapeGetCallbackKey))
                {
                    if (player.IsInVehicle) return;
                    colShape.GetData<Callback>(ColShapeGetCallbackKey)(player);
                }
            }
            else
            {
                if (colShape.HasData(ColShapeCefPathKey))
                {
                    if (player.Vehicle == null) return;
                    player.ChangeCefWindow(colShape.GetData<string>(ColShapeCefPathKey));
                }
                if (colShape.HasData(ColShapeGetCallbackKey))
                {
                    if (player.Vehicle == null) return;
                    colShape.GetData<Callback>(ColShapeGetCallbackKey)(player);
                }
            }
        }
    }
    
}