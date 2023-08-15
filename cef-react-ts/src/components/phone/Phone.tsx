import React from 'react';
import {Config} from "../../conf";
import {Space} from "antd";
import img from '../../assets/images/phone.png'


const Phone: React.FC = () => {
    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', justifyContent: 'end', alignItems: 'end'}}>
            <div style={{background: `url(${img}) no-repeat center/cover`, width: 300, height: 500, display: 'flex', justifyContent: 'center'}}>
                <div style={{border: '2px solid black', width: 221, height: 362, marginTop: 64, marginRight: 2}}>

                </div>
            </div>
        </Space>
    );
};

export default Phone;