using GTANetworkAPI;

namespace ServerSide.EventsHandlers;

public class CreateCharacter : Script
{
    [RemoteEvent("CEF::SERVER::ON_FINISH_CREATE_CHARACTER")]
    public async void OnFinishCreateCharacter(Player player, string character)
    {
        
    }
}