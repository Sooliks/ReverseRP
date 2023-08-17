import React, {useEffect, useState} from 'react';
import {Card, Space} from "antd";
import {Config} from "../../conf";
import DefaultColorPalette from "../../ui/DefaultColorPalette";
import ReverseColorPicker from "../../ui/ReverseColorPicker";

const CarDealership: React.FC = () => {
    type CarType = {
        id: number
        name: string
        capacityTrunk: number
        price: number
        countPassengers: number
    }

    const [currentCar,setCurrentCar] = useState<CarType>();
    const [cars,setCars] = useState<CarType[]>([])

    useEffect(()=>{
        setCars([{id: 0, name: 'BMW M8', capacityTrunk: 10, price: 1000000, countPassengers: 4}])
    },[])


    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', justifyContent: 'space-between'}}>
            <Card style={{height: 900, width: 290}}>
                <h1>dg</h1>
            </Card>
            {currentCar &&
                <Space direction={"vertical"}>
                    <ReverseColorPicker width={300} onPickColor={()=>{}}/>
                    <Card>
                        <Space direction={"vertical"}>

                        </Space>
                    </Card>
                </Space>
            }
        </Space>
    );
};

export default CarDealership;