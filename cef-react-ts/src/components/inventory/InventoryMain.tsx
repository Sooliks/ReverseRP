import React from 'react';
import Inventory from "./Inventory";
import InventoryContextProvider from "./context/InventoryContextProvider";

const InventoryMain: React.FC = () => {
    return (
        <InventoryContextProvider>
            <Inventory/>
        </InventoryContextProvider>
    );
};

export default InventoryMain;