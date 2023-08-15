import React from 'react';
import {Route, Routes} from "react-router-dom";
import Phone from "./components/phone/Phone";
import Hud from "./components/hud/Hud";

const DefaultRouter: React.FC = () => {
    return (
        <div>
            <Hud/>
            <Routes>
                <Route path={"/phone"} element={<Phone/>}/>
            </Routes>
        </div>
    );
};

export default DefaultRouter;