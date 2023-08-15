import React from 'react';
import {Config} from "../../conf";
import {Space} from "antd";

const Phone: React.FC = () => {
    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', justifyContent: 'end', alignItems: 'end'}}>
            <Space>
                <h1>fgfh</h1>
            </Space>
        </Space>
    );
};

export default Phone;