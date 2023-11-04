import React, {useEffect, useState} from 'react';
import {Config} from "../../conf";
import {Button, Card, Space} from "antd";
import {CloseOutlined} from "@ant-design/icons";
import {Client} from "../../requests/Client";
import Car from "./Car";

export type CarType = {
    id: number,
    name: string
    registerNumber: string
    vehicleTypeId: number
}

const ParkingPanel: React.FC = () => {
    const[cars,setCars] = useState<CarType[]>([
        {id: 1, name: 'BMW M8', registerNumber: 'AG534H', vehicleTypeId: 1},
        {id: 1, name: 'BMW M8', registerNumber: 'AG534H', vehicleTypeId: 1},
        {id: 1, name: 'BMW M8', registerNumber: 'AG534H', vehicleTypeId: 1},
        {id: 1, name: 'BMW M8', registerNumber: 'AG534H', vehicleTypeId: 1},
        {id: 1, name: 'BMW M8', registerNumber: 'AG534H', vehicleTypeId: 1},
        {id: 1, name: 'BMW M8', registerNumber: 'AG534H', vehicleTypeId: 1},
        {id: 1, name: 'BMW M8', registerNumber: 'AG534H', vehicleTypeId: 1},
        {id: 1, name: 'BMW M8', registerNumber: 'AG534H', vehicleTypeId: 1},
    ]);

    useEffect(()=>{

    },[])

    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', backgroundColor: 'white', justifyContent: 'center'}}>
            <Card title={"Стоянка"} extra={<Button icon={<CloseOutlined/>} onClick={()=>Client.closeWindow()}/>}>
                <div style={{width: '58vw', height: 560,overflowY: 'auto', display: 'flex', flexDirection: 'row', justifyContent: 'center'}}>
                    <Space size={[22,22]} wrap>
                        {cars.map((car,index)=>
                            <Car car={car} key={index}/>
                        )}
                    </Space>
                </div>
            </Card>
        </Space>
    );
};

export default ParkingPanel;