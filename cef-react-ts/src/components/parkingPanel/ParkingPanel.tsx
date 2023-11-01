import React, {useState} from 'react';
import {Config} from "../../conf";
import {Button, Card, Space} from "antd";
import {CloseOutlined} from "@ant-design/icons";
import {Client} from "../../requests/Client";

type Car = {

}

const ParkingPanel: React.FC = () => {
    const[cars,setCars] = useState<Car[]>([]);

    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', backgroundColor: 'white'}}>
            <Card extra={<Button icon={<CloseOutlined/>} onClick={()=>Client.closeWindow()}/>}>
                <div style={{width: '50vw', height: '50vh'}}>
                    <Space direction={"horizontal"}>
                        
                    </Space>
                </div>
            </Card>
        </Space>
    );
};

export default ParkingPanel;