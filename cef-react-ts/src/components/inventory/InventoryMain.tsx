import React from 'react';
import Inventory from "./Inventory";
import InventoryContextProvider from "./context/InventoryContextProvider";

const InventoryMain: React.FC = () => {
    return (
        <InventoryContextProvider>
            <div>
                <Inventory/>
            </div>
        </InventoryContextProvider>
    );
};

export default InventoryMain;