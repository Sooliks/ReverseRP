using System.Collections.Generic;
using System.IO;
using GTANetworkMethods;
using Newtonsoft.Json;
using ServerSide.Database.Handlers;
using ServerSide.Extensions;
using ServerSide.Services.MapService;

namespace ServerSide;

public class StartedCreateMarkers
{
    public static void LoadMarkers()
    {
        using (var r = new StreamReader("dotnet/resources/ReverseRP/ServerSide/Data/markersForWalking.json"))
        {
            string json = r.ReadToEnd();
            var markers = JsonConvert.DeserializeObject<List<MarkerModel>>(json);
            foreach (var marker in markers)
            {
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