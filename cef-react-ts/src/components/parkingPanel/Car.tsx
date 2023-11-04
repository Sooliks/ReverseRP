import React, {useEffect, useState} from 'react';
import {Button, Card, Space, Typography} from "antd";
import {CarType} from "./ParkingPanel";
import {Client} from "../../requests/Client";


type CarProps = {
    car: CarType
}
const {Text} = Typography;

const Car: React.FC<CarProps> = ({car}) => {
    const [image,setImage] = useState<string>('../../assets/images/vehicles/' + 'item_' + car.id + '.png')
    useEffect(()=>{
        try {
            setImage(require('../../assets/images/inventory/' + 'item_' + car.id + '.png'))
        }catch (e) {
            setImage(require('../../assets/images/not_found_car.png'));
        }
    })
    const handleClickGetVehicle = () => {
        Client.triggerServer("CEF::SERVER:GET_VEHICLE_FROM_PARKING",car.id);
    }


    return (
        <Card title={car.name}>
            <div style={{width: 200, height: 164, display: 'flex', flexDirection: 'column', justifyContent: 'space-between'}}>
                <img src={image} alt={"name"} style={{borderRadius: 10}}/>
                <Space style={{marginTop: 4}}>
                    <Text type={"secondary"}>Номерной знак: </Text>
                    <Text>{car.registerNumber}</Text>
                </Space>
                <Button type={"primary"} style={{width: '100%', marginBottom: 4}} onClick={handleClickGetVehicle}>Забрать</Button>
            </div>
        </Card>
    );
};

export default Car;