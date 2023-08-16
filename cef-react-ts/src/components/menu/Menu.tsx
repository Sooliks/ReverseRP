import React from 'react';
import {Space} from "antd";
import {Config} from "../../conf";


const Menu: React.FC = () => {
    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute'}}>

        </Space>
    );
};

export default Menu;