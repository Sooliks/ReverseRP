import React from 'react';
import {Route, Routes} from "react-router-dom";
import Phone from "./components/phone/Phone";
import Hud from "./components/hud/Hud";
import Chat from "./components/chat/Chat";

const DefaultRouter: React.FC = () => {
    return (
        <div>
            <Hud/>
            <Routes>
                <Route path={"/phone"} element={<Phone/>}/>
                <Route path={"/chatactive"} element={<Chat type={"active"}/>}/>
                <Route path={"/chatpassive"} element={<Chat type={"passive"}/>}/>
            </Routes>
        </div>
    );
};

export default DefaultRouter;