using GTANetworkAPI;
using ServerSide.Extensions;
using ServerSide.Services.MapService;
using ServerSide.Services.ServerServices;

namespace ServerSide.EventsHandlers.BusinessesEvents;

public class EventsCarDealerShip : Script
{
    private static readonly string ActiveViewCarKey = nameof(ActiveViewCarKey);
    
    [RemoteEvent("CEF::SERVER:SELECT_CAR_IN_CARDEALERSHIP")]
    public void OnSelectCar(Player player, int businessId, string modelHash)
    {
        if(!player.IsAuthorized())return;
        uint vehHash = NAPI.Util.GetHashKey(modelHash);
        if (player.HasData(ActiveViewCarKey))
        {
            var activeVeh = player.GetData<Vehicle>(ActiveViewCarKey);
            if(activeVeh.Model == vehHash)return;
            activeVeh.Delete();
        }
        Vehicle veh = NAPI.Vehicle.CreateVehicle(vehHash, new Vector3(-790.37256,-236.32191,37.35478), 162.7327f, 10, 10, dimension: player.Dimension);
        veh.NumberPlate = "Luxury";
        veh.Locked = true;
        veh.EngineStatus = false;
        player.SetData(ActiveViewCarKey,veh);
    }

    [RemoteEvent("CEF::SERVER:ON_EXIT_CARDEALERSHIP")]
    public void OnExitCarDealerShip(Player player)
    {
        InteriorService.ExitSoloInterior(player);
    }

    [RemoteEvent("CEF::SERVER:ON_PICK_COLOR_CARDEALEARSHIP")]
    public void OnPickColorCarDealerShip(Player player, string hexColor)
    {
        if (player.HasData(ActiveViewCarKey))
        {
            var activeVeh = player.GetData<Vehicle>(ActiveViewCarKey);
            var color = System.Drawing.ColorTranslator.FromHtml(hexColor);
            activeVeh.CustomPrimaryColor = new Color(color.R, color.G,color.B);
            activeVeh.CustomSecondaryColor = new Color(color.R, color.G,color.B);
        }
    }
}