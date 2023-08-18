import React, {useEffect, useState} from 'react';
import {Button, Card, Descriptions, Divider, Drawer, Space, Typography} from "antd";
import {Config} from "../../conf";
import DefaultColorPalette from "../../ui/DefaultColorPalette";
import ReverseColorPicker from "../../ui/ReverseColorPicker";
import ReverseList from "../../ui/ReverseList";

const {Title, Text} = Typography;


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
            {id: 1, name: 'BMW M5 Competition', capacityTrunk: 20, price: 1200000, countPassengers: 2, value: 'bmw m5'},
        ])
    },[])

    const handleClickSetCurrentCar = (name: string, value: string) => {
        const index: number = cars.findIndex(c=>c.name === name);
        setCurrentCar(cars[index]);
    }

    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', justifyContent: 'space-between'}}>
            <ReverseList onClick={handleClickSetCurrentCar} data={cars}/>
            {currentCar &&
                <Space direction={"vertical"}>
                    <ReverseColorPicker width={300} onPickColor={()=>{}}/>
                    <Card style={{display: 'flex', flexDirection: 'row', flexWrap: 'wrap'}}>
                        <Space direction={"vertical"} style={{width: 300}}>
                            <Title level={4}>Характеристики</Title>
                            <Space>
                                <Text type={"secondary"}>Цена:</Text>
                                <Text>{currentCar.price + '$'}</Text>
                            </Space>
                            <Space>
                                <Text type={"secondary"}>Кол-во посадочных мест:</Text>
                                <Text>{currentCar.countPassengers}</Text>
                            </Space>
                            <Space>
                                <Text type={"secondary"}>Вместимость багажника:</Text>
                                <Text>{currentCar.capacityTrunk + ' кг'}</Text>
                            </Space>
                        </Space>
                        <Divider/>
                        <Space style={{justifyContent: 'space-between', width: '100%'}}>
                            <Button type={"primary"}>Купить</Button>
                            <Button>Тест драйв</Button>
                        </Space>
                    </Card>
                </Space>
            }
        </Space>
    );
};

export default CarDealership;