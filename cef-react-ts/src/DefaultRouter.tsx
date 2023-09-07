import React, {useState} from 'react';
import {Route, Routes} from "react-router-dom";
import Phone from "./components/phone/Phone";
import Hud from "./components/hud/Hud";
import Chat from "./components/chat/Chat";

const DefaultRouter: React.FC = () => {
    const[typeChat,setTypeChat] = useState<"passive" | "active">("passive")


    return (
        <div>
            <Hud/>
            <Chat type={typeChat}/>
            <Routes>
                <Route path={"/phone"} element={<Phone/>}/>
                <Route path={"/chatactive"}  element={<Chat type={typeChat}/>}/>
            </Routes>
        </div>
    );
};

export default DefaultRouter;