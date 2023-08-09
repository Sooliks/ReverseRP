import React, {createContext, useContext, useState} from 'react';
import {ItemType} from "../Item";
import {BoardType} from "../Board";



export type InventoryType = {
    currentItem?: ItemType
    boardsPlayer: BoardType[]
    boardsClothes: BoardType[]
    boardsOther: BoardType[]
}
type InventoryContextProviderProps = {
    children: React.ReactNode
}

type InventoryContextType = {
    inventory: InventoryType;
    setInventory: React.Dispatch<React.SetStateAction<InventoryType>>
}
const InventoryContext = createContext({} as InventoryContextType)

export const useInventoryContext = () =>  useContext(InventoryContext);

export const defaultInventory: InventoryType = {
    boardsPlayer: [],
    boardsClothes: [],
    boardsOther: []
}


const InventoryContextProvider = ({children}: InventoryContextProviderProps) => {
    const [inventory,setInventory] = useState<InventoryType>(defaultInventory);



    return (
        <InventoryContext.Provider value={{inventory,setInventory}}>{children}</InventoryContext.Provider>
    );
};

export default InventoryContextProvider;