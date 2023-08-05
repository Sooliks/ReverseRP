import React, {createContext, useContext, useState} from 'react';


export type NavigationType = {
    hud?: boolean;
    speedometer?: boolean;
}
type NavigationContextProviderProps = {
    children: React.ReactNode
}

type NavigationContextType = {
    navigation: NavigationType | null;
    setNavigation: React.Dispatch<React.SetStateAction<NavigationType | null>>
}
const NavigationContext = createContext({} as NavigationContextType)

export const useNavigationContext = () =>  useContext(NavigationContext);

const NavigationContextProvider = ({children}:NavigationContextProviderProps) => {

    const [navigation,setNavigation] = useState<NavigationType | null>({hud: false, speedometer: false});

    return (
        <NavigationContext.Provider value={{navigation,setNavigation}}>{children}</NavigationContext.Provider>
    );
};

export default NavigationContextProvider;