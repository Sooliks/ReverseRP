using ClientSide.CEF;
using RAGE;
using RAGE.Ui;

namespace ClientSide.Keys
{
    public class Keys : Events.Script
    {
        public Keys()
        {
            Input.Bind(VirtualKeys.F2, true, () =>
            {
                Cursor.ShowCursor(!Cursor.Visible,!Cursor.Visible);
            });
            Input.Bind(VirtualKeys.I, true, () =>
            {
                CefService.ChangePath("/inventory");
            });
        }
    }
}