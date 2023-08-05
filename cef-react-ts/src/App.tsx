import React, {useEffect} from 'react';
import {BrowserRouter} from "react-router-dom";
import NavigationContextProvider from "./context/NavigationContextProvider";
import Hud from "./components/hud/Hud";
import AppRouter from "./AppRouter";
import {Config} from "./conf";



const App = () => {

    useEffect(()=>{
        /*notification.error({
            message: "Уведомление",
            description: "Подтвердите аккаунт в настройках, иначе не сможете восстановить его в случае утери"
        })*/
    },[])



    return (
        <NavigationContextProvider>
            <div style={{width:Config.screenResolution.width, height:Config.screenResolution.height, backgroundImage: Config.isDevelopment ? `url('https://www.digiseller.ru/preview/858000/p1_3575817_2fcd5317.jpg')` : ``}}>
                <Hud/>
                <BrowserRouter>
                    <AppRouter/>
                </BrowserRouter>
            </div>
        </NavigationContextProvider>
    );
}

export default App;
