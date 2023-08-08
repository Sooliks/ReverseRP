using GTANetworkAPI;

namespace ServerSide.EventsHandlers;

public class SelectCharacter : Script
{
    [RemoteEvent("CEF::SERVER::ON_CLICK_CREATE_CHARACTER")]
    public async void OnClickCreateCharacter(Player player)
    {
        
    }
}