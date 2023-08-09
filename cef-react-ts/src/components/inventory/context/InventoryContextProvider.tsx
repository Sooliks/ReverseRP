import React, {createContext, useContext, useState} from 'react';




type InventoryOther = {

}
type InventoryPlayer = {

}


export type InventoryType = {

}
type InventoryContextProviderProps = {
    children: React.ReactNode
}

type InventoryContextType = {
    character: InventoryType;
    setCharacter: React.Dispatch<React.SetStateAction<InventoryType>>
}
const InventoryContext = createContext({} as InventoryContextType)

export const useInventoryContext = () =>  useContext(InventoryContext);

export const defaultInventory: InventoryType = {

}

const InventoryContextProvider = ({children}: InventoryContextProviderProps) => {

    const [character,setCharacter] = useState<InventoryType>(defaultInventory);


    return (
        <InventoryContext.Provider value={{character,setCharacter}}>{children}</InventoryContext.Provider>
    );
};

export default InventoryContextProvider;