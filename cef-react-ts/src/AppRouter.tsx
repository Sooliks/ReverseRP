import React from 'react';
import {Route, Routes} from "react-router-dom";
import Auth from "./components/auth/Auth";
import CreateCharacter from "./components/character/createCharacter/CreateCharacter";
import SelectCharacters from "./components/character/selectCharacters/SelectCharacters";
import Hud from "./components/hud/Hud";
import InventoryMain from "./components/inventory/InventoryMain";

const AppRouter: React.FC = () => {
    try{

    }catch (e){}


    return (
        <Routes>
            <Route path={"/auth"} element={<Auth/>}/>
            <Route path={"/createcharacter"} element={<CreateCharacter/>}/>
            <Route path={"/selectcharacters"} element={<SelectCharacters/>}/>
            <Route path={"/"} element={<Hud/>}/>
            <Route path={"/inventory"} element={<InventoryMain/>}/>
        </Routes>
    );
};

export default AppRouter;