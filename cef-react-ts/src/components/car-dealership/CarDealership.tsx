import React, {useEffect, useState} from 'react';
import {Card, Space} from "antd";
import {Config} from "../../conf";
import DefaultColorPalette from "../../ui/DefaultColorPalette";
import ReverseColorPicker from "../../ui/ReverseColorPicker";
import ReverseList from "../../ui/ReverseList";

const CarDealership: React.FC = () => {
    type CarType = {
        id: number
        name: string
        capacityTrunk: number
        price: number
        countPassengers: number
        value: string
    }

    const [currentCar,setCurrentCar] = useState<CarType>();
    const [cars,setCars] = useState<CarType[]>([])

    useEffect(()=>{
        setCars([
            {id: 0, name: 'BMW M8', capacityTrunk: 10, price: 1000000, countPassengers: 4, value: 'bmw m8'},
            {id: 0, name: 'BMW M8', capacityTrunk: 10, price: 1000000, countPassengers: 4, value: 'bmw m8'},
        ])
    },[])


    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', justifyContent: 'space-between'}}>
            <ReverseList data={cars}/>
            {currentCar &&
                <Space direction={"vertical"}>
                    <ReverseColorPicker width={250} onPickColor={()=>{}}/>
                    <Card>

                    </Card>
                </Space>
            }
        </Space>
    );
};

export default CarDealership;