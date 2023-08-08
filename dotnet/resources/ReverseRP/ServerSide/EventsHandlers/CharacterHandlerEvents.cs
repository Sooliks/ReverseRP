using GTANetworkAPI;

namespace ServerSide.EventsHandlers;

public class CharacterHandlerEvents : Script
{
    [RemoteEvent("CEF::SERVER::ON_FINISH_CREATE_CHARACTER")]
    public async void OnFinishRegistration(Player player)
    {
        
    }
}