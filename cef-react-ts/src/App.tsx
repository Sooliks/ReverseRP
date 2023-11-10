import React, {useEffect} from 'react';
import {BrowserRouter} from "react-router-dom";
import NavigationContextProvider from "./context/NavigationContextProvider";
import Hud from "./components/hud/Hud";
import AppRouter from "./AppRouter";
import {Config} from "./conf";
import {notification} from "antd";
import {Client} from "./requests/Client";
import {ServerData} from "./data/ServerData";





const App = () => {
    useEffect(()=>{
        /*Client.callProcServer<string>("RPC::CEF::SERVER:GetVehiclesTypes").then(data => {
            ServerData.vehiclesTypes = JSON.parse(data);
        })*/
        Client.callProcServer<string>("RPC::CEF::SERVER:GetItemTypes").then(data => {
            ServerData.itemsTypes = JSON.parse(data);
        })
    },[])


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
