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
import MarketPlace from "./components/marketplace/MarketPlace";
import ManagementsBusiness from "./components/management-business/ManagementsBusiness";
import InformationOfBusiness from "./components/info-business/InformationOfBusiness";
import AdminPanel from "./components/adminpanel/AdminPanel";
import GasStation from "./components/gas-station/GasStation";

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
                <Route path={"/market/:id"} element={<Market/>}/>
                <Route path={"/marketplace"} element={<MarketPlace/>}/>
                <Route path={"/managementbusiness/:id"} element={<ManagementsBusiness/>}/>
                <Route path={"/informationbusiness/:id"} element={<InformationOfBusiness/>}/>
                <Route path={"/adminpanel"} element={<AdminPanel/>}/>
                <Route path={"/gasstation/:id"} element={<GasStation/>}/>
                <Route path={"/*"} element={<DefaultRouter/>}/>
            </Routes>
        </App>
    );
};

export default AppRouter;