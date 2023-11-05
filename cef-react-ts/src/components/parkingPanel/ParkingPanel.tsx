import React, {useEffect, useState} from 'react';
import {Config} from "../../conf";
import {Button, Card, Result, Space} from "antd";
import {CloseOutlined} from "@ant-design/icons";
import {Client} from "../../requests/Client";
import Car from "./Car";
import {useParams} from "react-router-dom";

export type CarType = {
    id: number,
    name: string
    registerNumber: string
    vehicleTypeId: number
}
type ParkingPanelParams = {
    id: string
}

const ParkingPanel: React.FC = () => {
    const params = useParams<ParkingPanelParams>();
    const[cars,setCars] = useState<CarType[]>([]);

    useEffect(()=>{
        Client.callProcServer<string>("RPC::CEF::SERVER:GET_VEHICLES_CHARACTER").then(data=>{
            setCars(JSON.parse(data));
        })
    },[])

    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', backgroundColor: 'white', justifyContent: 'center'}}>
            <Card title={"Стоянка"} extra={<Button icon={<CloseOutlined/>} onClick={()=>Client.closeWindow()}/>}>
                <div style={{width: '58vw', height: 560,overflowY: 'auto'}}>
                    {cars.length!==0 ?
                        <Space size={[22,22]} wrap>
                            {cars.map((car,index)=>
                                <Car idParking={params.id} car={car} key={index}/>
                            )}
                        </Space>
                        :
                        <Result title="Вы не имеете не одного т/с" style={{marginTop: 120}}/>
                    }
                </div>
            </Card>
        </Space>
    );
};

export default ParkingPanel;