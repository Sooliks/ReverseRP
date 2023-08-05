export namespace Client{
    export const triggerServer = (name: string, ...args: any[]) => {
        mp.trigger("REDIRECT::CEF_TO_SERVER",name,...args);
    }
}