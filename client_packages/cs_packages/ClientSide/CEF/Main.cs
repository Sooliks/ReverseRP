using RAGE;
using RAGE.Ui;

namespace ClientSide.CEF
{
    public class Main : Events.Script
    {
        public static HtmlWindow MainCefWindow = new HtmlWindow("http://localhost:3000");
        public Main()
        {
            MainCefWindow.Active = true;
            Events.Add("SERVER::CLIENT::CHANGE_WINDOW",OnChangeWindow);
        }
        
        public static void ChangePath(string path) => MainCefWindow.Url = "http://localhost:3000" + path;
        private void OnChangeWindow(object[] args)
        {
            string path = (string)args[0];
            ChangePath(path);
            if (path == "")
            {
                RAGE.Ui.Cursor.ShowCursor(false,false);
                RAGE.Chat.Activate(true);
            }
            else
            {
                RAGE.Ui.Cursor.ShowCursor(true,true);
                RAGE.Chat.Activate(false);
            }
        }
    }
}