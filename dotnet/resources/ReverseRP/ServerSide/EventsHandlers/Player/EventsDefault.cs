using GTANetworkAPI;

namespace ServerSide.EventsHandlers.Player;

public class EventsDefault
{
    [RemoteEvent("CLIENT:SERVER::OnTeleport")]
    public async void OnClickCreateCharacter(GTANetworkAPI.Player player)
    {
        
    }
}