import React, {useEffect, useState} from 'react';
import {Config} from "../../conf";
import {Button, Card, Space} from "antd";
import {CloseOutlined} from "@ant-design/icons";
import {Client} from "../../requests/Client";

export type CarType = {
    id: number,
    name: string
    registerNumber: string
    vehicleTypeId: number
}

const ParkingPanel: React.FC = () => {
    const[cars,setCars] = useState<CarType[]>([]);

    useEffect(()=>{

    },[])

    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', backgroundColor: 'white', justifyContent: 'center'}}>
            <Card extra={<Button icon={<CloseOutlined/>} onClick={()=>Client.closeWindow()}/>}>
                <div style={{width: '50vw', height: '50vh'}}>
                    <Space direction={"horizontal"} wrap>
                        
                    </Space>
                </div>
            </Card>
        </Space>
    );
};

export default ParkingPanel;