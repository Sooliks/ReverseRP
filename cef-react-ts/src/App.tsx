import React, {useEffect} from 'react';
import {BrowserRouter} from "react-router-dom";
import NavigationContextProvider from "./context/NavigationContextProvider";
import Hud from "./components/hud/Hud";
import AppRouter from "./AppRouter";
import {Config} from "./conf";
import {notification} from "antd";



const App = () => {
    mp.events.add("SERVER:CEF::NOTIFY", (json: string)=>{
        const args: any[] = JSON.parse(json);
        const type: number = args[0];
        const message: string = args[1];
        switch (type){
            case 0:
                notification.error({
                    message: "Уведомление",
                    description: message
                })
                break
            case 1:
                notification.success({
                    message: "Уведомление",
                    description: message
                })
                break
            case 2:
                notification.info({
                    message: "Уведомление",
                    description: message
                })
                break
            case 3:
                notification.warning({
                    message: "Уведомление",
                    description: message
                })
                break
        }
    })

    
    return (
        <NavigationContextProvider>
            <div style={{width:Config.screenResolution.width, height:Config.screenResolution.height, backgroundImage: Config.isDevelopment ? `url('https://www.digiseller.ru/preview/858000/p1_3575817_2fcd5317.jpg')` : ``}}>
                <BrowserRouter>
                    <AppRouter/>
                </BrowserRouter>
            </div>
        </NavigationContextProvider>
    );
}

export default App;
