import React from 'react';
import {Route, Routes} from "react-router-dom";
import Auth from "./components/auth/Auth";
import CreateCharacter from "./components/character/createCharacter/CreateCharacter";
import SelectCharacters from "./components/character/selectCharacters/SelectCharacters";

const AppRouter: React.FC = () => {
    return (
        <Routes>
            <Route path={"/auth"} element={<Auth/>}/>
            <Route path={"/createcharacter"} element={<CreateCharacter/>}/>
            <Route path={"/selectcharacters"} element={<SelectCharacters/>}/>
        </Routes>
    );
};

export default AppRouter;