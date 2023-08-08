import React, {createContext, useContext, useEffect, useState} from 'react';


export type CreateCharacterType = {
    gender: string,
    firstName: string,
    lastName: string,
    birth: number,
    promo: string,
    origin: string,
    hair: number[],
    blendData: number[],
    faceFeatures: number[],
    clothing: number[],
    headOverlays: number[],
    headOverlaysColors: number[]
}
type CreateCharacterContextProviderProps = {
    children: React.ReactNode
}

type CreateCharacterContextType = {
    character: CreateCharacterType;
    setCharacter: React.Dispatch<React.SetStateAction<CreateCharacterType>>
}
const CreateCharacterContext = createContext({} as CreateCharacterContextType)

export const useCreateCharacterContext = () =>  useContext(CreateCharacterContext);

export const defaultCharacter: CreateCharacterType = {
    gender: 'мужской',
    firstName: '',
    lastName: '',
    birth: 23,
    promo:'',
    origin: 'Los-Santos',
    hair: [3,0],
    blendData: [0, 0, 0.5, 0.5,  0,  0],
    faceFeatures: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    clothing: [0, 1, 5],
    headOverlays: [255, 255, 12, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255],
    headOverlaysColors: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
}

const NavigationContextProvider = ({children}: CreateCharacterContextProviderProps) => {

    const [character,setCharacter] = useState<CreateCharacterType>(defaultCharacter);


    return (
        <CreateCharacterContext.Provider value={{character,setCharacter}}>{children}</CreateCharacterContext.Provider>
    );
};

export default NavigationContextProvider;