export namespace Client{
    export const triggerServer = (name: string, ...args: any[]) => {
        mp.trigger("REDIRECT::CEF_TO_SERVER",name,...args);
    }
    export async function callProcServer<T = any>(name: string, ...args: any[]): Promise<T> {
        const res: T = await mp.events.callProc<T>("RPC::REDIRECT::CEF_TO_SERVER",name,...args);
        return res;
    }
}