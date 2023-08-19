export namespace Client{
    export const triggerServer = (name: string, ...args: any[]) => {
        mp.trigger("REDIRECT::CEF_TO_SERVER",name,...args);
    }
    export function callProcServer<T = any>(name: string, ...args: any[]): Promise<T> {
        return mp.events.callProc<T>("RPC::REDIRECT::CEF_TO_SERVER",name,...args)
    }
}