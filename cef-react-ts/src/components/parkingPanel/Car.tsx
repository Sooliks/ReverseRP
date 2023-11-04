import React, {useEffect, useState} from 'react';
import {Button, Card} from "antd";
import {CarType} from "./ParkingPanel";


type CarProps = {
    car: CarType
}


const Car: React.FC<CarProps> = ({car}) => {
    const [image,setImage] = useState<string>('../../assets/images/vehicles/' + 'item_' + car.id + '.png')
    useEffect(()=>{
        try {
            setImage(require('../../assets/images/inventory/' + 'item_' + car.id + '.png'))
        }catch (e) {
            setImage(require('../../assets/images/not_found_car.png'));
        }
    })


    return (
        <Card title={car.name}>
            <div style={{width: 200, height: 160}}>
                <img src={image} alt={"name"}/>
                <Button type={"primary"} style={{width: '100%'}}>Забрать</Button>
            </div>
        </Card>
    );
};

export default Car;