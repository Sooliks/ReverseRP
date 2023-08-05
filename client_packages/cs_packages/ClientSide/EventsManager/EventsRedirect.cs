using RAGE;
using System.Linq;



namespace ClientSide.EventsManager
{
    public class EventsRedirect : Events.Script
    {
        public EventsRedirect()
        {
            Events.Add("REDIRECT::CEF_TO_SERVER", OnRedirectCefToServer);
            Events.Add("REDIRECT::SERVER_TO_CEF", OnRedirectServerToCef);
        }

        private void OnRedirectCefToServer(object[] args)
        {
            string nameServerEvent = (string)args[0];
            args = args.Where(e => e != nameServerEvent).ToArray();
            Events.CallRemote(nameServerEvent, args);
        }
        private void OnRedirectServerToCef(object[] args)
        {
            string nameCefEvent = (string)args[0];
            args = args.Where(e => e != nameCefEvent).ToArray();
            CEF.Main.MainCefWindow.Call(nameCefEvent, args);
        }
    }
}