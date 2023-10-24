using System;
using System.Collections.Generic;
using System.IO;
using GTANetworkAPI;
using GTANetworkMethods;
using Newtonsoft.Json;
using ServerSide.Database.Handlers;
using ServerSide.Enums;
using ServerSide.EventsHandlers.BusinessesEvents;
using ServerSide.Extensions;
using ServerSide.Extensions.VehicleExtensions;
using ServerSide.Services.MapService;
using ServerSide.Services.ServerServices;

namespace ServerSide;

public class StartedCreateMarkers
{
    public static void LoadMarkers()
    {
        using (var r = new StreamReader("dotnet/resources/ReverseRP/ServerSide/Data/markers.json"))
        {
            string json = r.ReadToEnd();
            var markers = JsonConvert.DeserializeObject<List<MarkerModel>>(json);
            foreach (var marker in markers)
            {
                if (marker.NameCefPath.StartsWith("/cardealership"))
                {
                    InputMarker.CreateDefaultInputMarkerWithFuncCallback(marker.TextLabel,marker.Position, marker.IconBlip, marker.ColorBlip,player =>
                    {
                        if(player.IsExitInterior())return;
                        player.ChangeCefWindow(marker.NameCefPath);
                        DimensionService.SetUniqueDimension(player);
                        player.SetCamera(new Vector3(-789.714f,-242.11792f,37.734104f+2f), new Vector3(-790.37256f,-236.32191f,37.35478f), true);
                    });
                    continue;
                }
                if (marker.NameCefPath.StartsWith("/gasstation"))
                {
                    InputMarker.CreateColShapeWithCallback(marker.Position, 5, player =>
                    {
                        if (player.Vehicle.GetVehicleModel() == null)
                        {
                            player.SendNotify(NotifyType.Warning, "Вы не можете заправить это т/с");
                            return;
                        }
                        if (player.Vehicle.EngineStatus)
                        {
                            player.SendNotify(NotifyType.Warning, "Заглушите двигатель");
                            return;
                        }
                        player.ChangeCefWindow(marker.NameCefPath);
                        
                    }, false, true);
                    continue;
                }
                InputMarker.CreateDefaultInputMarkerWithOpenCefPath(marker.TextLabel, marker.Position, marker.IconBlip, marker.ColorBlip, marker.NameCefPath);
            }
        }
        foreach (var business in BusinessHandler.GetAllBusinesses())
        {
            InputMarker.CreateDefaultInputMarkerWithFuncCallbackWithoutBlip("Информация", business.PositionManagementBusiness,
                player =>
                {
                    if (BusinessHandler.IsCharacterOwnerBusiness(player.GetCharacter(), BusinessHandler.GetBusinessById(business.Id)))
                    {
                        player.ChangeCefWindow($"/managementbusiness/{business.Id}");
                    }
                    else
                    {
                        player.ChangeCefWindow($"/informationbusiness/{business.Id}");;
                    }
                });
        }
    }
}