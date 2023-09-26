using RAGE;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSide.ProcedureManager
{
    public class ProcedureRedirect : Events.Script
    {
        public ProcedureRedirect()
        {
            Events.AddProc("RPC::REDIRECT::CEF_TO_SERVER", OnRedirect, true);
        }
        private async Task<string> OnRedirect(object[] args)
        {
            string nameServerProc = (string)args[0];
            args = args.Where(e => e != nameServerProc).ToArray();
            var res = (string) await Events.CallRemoteProc(nameServerProc,args);
            RAGE.Chat.Output(res);
            return res;
        }
    }
}