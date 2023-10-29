import React, {useState} from 'react';
import {Config} from "../../../conf";
import {Space} from "antd";

const Truckers: React.FC = () => {
    const [level,setLevel] = useState<number>(0);
    

    return (
        <Space style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <p>fgfgfg</p>
        </Space>
    );
};

export default Truckers;