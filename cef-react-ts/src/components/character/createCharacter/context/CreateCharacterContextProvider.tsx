import React, {createContext, useContext, useEffect, useState} from 'react';


export type CreateCharacterType = {
    gender: string,
    firstName: string,
    lastName: string,
    birth: number,
    promo: string,
    origin: string,
    hair: number[],
    beard: number[],
    blendData: number[],
    faceFeatures: number[],
    torso: number,
    clothing: number[],
    headOverlays: number[],
    headOverlaysColors: number[]
    eyeColor: number,
    eyeBrowColor: number,
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

const NavigationContextProvider = ({children}: CreateCharacterContextProviderProps) => {

    const [character,setCharacter] = useState<CreateCharacterType>({
        gender: 'мужской',
        firstName: '',
        lastName: '',
        birth: 23,
        promo:'',
        origin: 'Los-Santos',
        hair: [2,0],
        beard: [255, 0],
        blendData: [0, 0, 0.5, 0.5,  0,  0],
        faceFeatures: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
        torso: 0,
        clothing: [0, 0, 0, 0],
        headOverlays: [255, 255, 12, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255],
        headOverlaysColors: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
        eyeColor: 0,
        eyeBrowColor: 0,
    });


    return (
        <CreateCharacterContext.Provider value={{character,setCharacter}}>{children}</CreateCharacterContext.Provider>
    );
};

export default NavigationContextProvider;