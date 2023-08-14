export namespace Client{
    export const triggerServer = (name: string, ...args: any[]) => {
        mp.trigger("REDIRECT::CEF_TO_SERVER",name,...args);
    }
    export const callProcServer = (name: string, ...args: any[]) => {
        return mp.events.callProc("RPC::REDIRECT::CEF_TO_SERVER",name,...args)
    }
}