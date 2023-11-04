import React, {useEffect, useState} from 'react';
import {Button, Card, Space, Typography} from "antd";
import {CarType} from "./ParkingPanel";
import {Client} from "../../requests/Client";
import Information from "../../ui/Information";


type CarProps = {
    car: CarType
    idParking?: string
}
const {Text} = Typography;

const Car: React.FC<CarProps> = ({car,idParking}) => {
    const [image,setImage] = useState<string>('../../assets/images/vehicles/' + 'item_' + car.id + '.png')
    useEffect(()=>{
        try {
            setImage(require('../../assets/images/vehicles/' + 'item_' + car.id + '.png'))
        }catch (e) {
            setImage(require('../../assets/images/not_found_car.png'));
        }
    })
    const handleClickGetVehicle = () => {
        Client.triggerServer("CEF::SERVER:GET_VEHICLE_FROM_PARKING",car.id,Number(idParking));
    }


    return (
        <Card title={car.name}>
            <div style={{width: 200, height: 164, display: 'flex', flexDirection: 'column', justifyContent: 'space-between'}}>
                <img src={image} alt={"name"} style={{borderRadius: 10}} width={200} height={121}/>
                <Information style={{marginTop: 4}} text={["Номерной знак: "]} data={[car.registerNumber]}/>
                <Button type={"primary"} style={{width: '100%', marginBottom: 4}} onClick={handleClickGetVehicle}>Забрать</Button>
            </div>
        </Card>
    );
};

export default Car;