import React, {useState} from 'react';
import {Config} from "../../../conf";
import {Button, Card, Space} from "antd";
import {CloseOutlined} from "@ant-design/icons";
import {Client} from "../../../requests/Client";

type Level = {
    vehicleHash: string
    nameVehicle: string

}

const Truckers: React.FC = () => {
    const [levelWork,setLevelWork] = useState<number>(0);
    const [levels,setLevels] = useState<Level[]>([
        {vehicleHash: "teslax", nameVehicle: "Truck 1"},
        {vehicleHash: "teslax", nameVehicle: "Truck 1"},
    ])

    return (
        <Space style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <Card title={"Работа: Дальнобойщик"} extra={<Button icon={<CloseOutlined/>} onClick={()=>Client.closeWindow()}/>}>
                <div style={{width: '58vw', height: 560,overflowY: 'auto'}}>
                    
                </div>
            </Card>
        </Space>
    );
};

export default Truckers;