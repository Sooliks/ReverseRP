using RAGE;
using RAGE.Ui;

namespace ClientSide.CEF
{
    public class CefService : Events.Script
    {
        public static HtmlWindow MainCefWindow = new HtmlWindow("http://localhost:3000");
        public static List<string> PathToWindowsOpenByKey = new List<string>()
        {
            "/inventory",
            "/phone"
        };
        public CefService()
        {
            MainCefWindow.Active = true;
            Events.Add("SERVER::CLIENT::CHANGE_WINDOW",OnChangeWindow);
        }
        private static void ChangePath(string path) => MainCefWindow.Url = "http://localhost:3000" + path;

        public static void SwapPath(string path)
        {
            if (IsPathCanOpen(path))
            {
                if (path == "")
                {
                    ChangePath(path);
                    RAGE.Ui.Cursor.ShowCursor(false, false);
                    RAGE.Chat.Activate(true);
                    return;
                }
                else
                {
                    ChangePath(path);
                    RAGE.Ui.Cursor.ShowCursor(true, true);
                    RAGE.Chat.Activate(false);
                    return;
                }
            }
            else
            {
                if (path == "")
                {
                    ChangePath(path);
                    RAGE.Ui.Cursor.ShowCursor(false, false);
                    RAGE.Chat.Activate(true);
                    return;
                }
            }
        }
        private void OnChangeWindow(object[] args)
        {
            string path = (string)args[0];
            if (IsPathCanOpen(path))
            {
                if (path == "")
                {
                    ChangePath(path);
                    RAGE.Ui.Cursor.ShowCursor(false, false);
                    RAGE.Chat.Activate(true);
                    return;
                }
                else
                {
                    ChangePath(path);
                    RAGE.Ui.Cursor.ShowCursor(true, true);
                    RAGE.Chat.Activate(false);
                    return;
                }
            }
            else
            {
                if (path == "")
                {
                    ChangePath(path);
                    RAGE.Ui.Cursor.ShowCursor(false, false);
                    RAGE.Chat.Activate(true);
                    return;
                }
            }
        }
        private static bool IsPathCanOpen(string path)
        {
            foreach (var p in PathToWindowsOpenByKey)
            {
                if(p==path)return false;
            }
            return true;
        }
    }
}