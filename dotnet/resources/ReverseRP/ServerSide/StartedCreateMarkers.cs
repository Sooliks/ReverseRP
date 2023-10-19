using System.Collections.Generic;
using System.IO;
using GTANetworkMethods;
using Newtonsoft.Json;
using ServerSide.Database.Handlers;
using ServerSide.Enums;
using ServerSide.Extensions;
using ServerSide.Services.MapService;

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
                        player.ChangeCefWindow(marker.NameCefPath);
                    });
                    continue;
                }
                if (marker.NameCefPath.StartsWith("/gasstation"))
                {
                    InputMarker.CreateColShapeWithCallback(marker.Position, 5, player =>
                    {
                        if (player.Vehicle.EngineStatus)
                        {
                            player.SendNotify(NotifyType.Warning, "Заглушите двигатель");
                        }
                        else
                        {
                            player.ChangeCefWindow(marker.NameCefPath);
                        }
                    }, marker.IsForWalking, true);
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