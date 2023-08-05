import React, {useEffect} from 'react';
import {Space} from "antd";
import {useNavigationContext} from "../../context/NavigationContextProvider";
import {Config} from "../../conf";
import Keys from "./Keys";






const Hud : React.FC = () => {
    const navigationContext = useNavigationContext();

    useEffect(()=>{

    },[])

    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute'}}>
            {navigationContext.navigation?.hud &&
                <Space>
                    <Space align={"center"} style={{marginLeft:20}}>
                        <Keys/>
                    </Space>
                </Space>
            }
        </Space>
    );
};

export default Hud;