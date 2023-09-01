import React from 'react';
import {Route, Routes} from "react-router-dom";
import Auth from "./components/auth/Auth";
import CreateCharacter from "./components/character/createCharacter/CreateCharacter";
import SelectCharacters from "./components/character/selectCharacters/SelectCharacters";
import InventoryMain from "./components/inventory/InventoryMain";
import { App } from 'antd';
import DefaultRouter from "./DefaultRouter";
import ReverseMenu from "./components/menu/ReverseMenu";
import CarDealership from "./components/car-dealership/CarDealership";
import Market from "./components/shop24/Market";

const AppRouter: React.FC = () => {
    const { message, notification, modal } = App.useApp();


    return (
        <App>
            <Routes>
                <Route path={"/auth"} element={<Auth/>}/>
                <Route path={"/createcharacter"} element={<CreateCharacter/>}/>
                <Route path={"/selectcharacters"} element={<SelectCharacters/>}/>
                <Route path={"/inventory"} element={<InventoryMain/>}/>
                <Route path={"/menu"} element={<ReverseMenu/>}/>
                <Route path={"/cardealership"} element={<CarDealership/>}/>
                <Route path={"/market"} element={<Market/>}/>
                <Route path={"/*"} element={<DefaultRouter/>}/>
            </Routes>
        </App>
    );
};

export default AppRouter;