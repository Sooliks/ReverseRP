using RAGE;
using System.Linq;

namespace ClientSide.ProcedureManager
{
    public class ProcedureRedirect : Events.Script
    {
        public ProcedureRedirect()
        {
            Events.AddProc("RPC::REDIRECT::CEF_TO_SERVER",(args) =>
            {
                string nameServerProc = (string)args[0];
                args = args.Where(e => e != nameServerProc).ToArray();
                var res = Events.CallRemoteProc(nameServerProc,args);
                
                return res.Result;
            });
        }
    }
}