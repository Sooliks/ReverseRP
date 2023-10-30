import React, {useEffect, useState} from 'react';
import {Button, Card, Descriptions, Divider, Drawer, Space, Typography} from "antd";
import {Config} from "../../conf";
import DefaultColorPalette from "../../ui/DefaultColorPalette";
import ReverseColorPicker from "../../ui/ReverseColorPicker";
import ReverseList from "../../ui/ReverseList";
import {useParams} from "react-router-dom";
import {Client} from "../../requests/Client";
import {IncomingItemBusiness} from "../../types/businessesTypes";
import {VehicleType} from "../../types/vehicleType";
import {ServerData} from "../../data/ServerData";

const {Title, Text} = Typography;

type CarDealershipParams = {
    id: string
}


const CarDealership: React.FC = () => {
    const params = useParams<CarDealershipParams>();
    type CarType = {
        price: number
        VehicleType: VehicleType | undefined
    }

    const [currentCar,setCurrentCar] = useState<CarType>();
    const [cars,setCars] = useState<CarType[]>([])
    const [listCars,setListCars] = useState<{name: string, value: string}[]>([])
    const [currentColor,setCurrentColor] = useState<{index: number, hexColor: string | undefined}>();

    useEffect(()=>{
        Client.callProcServer<string>("RPC::CEF::SERVER:GetVehiclesTypes").then(data=>{
            ServerData.vehiclesTypes = JSON.parse(data);
        })
        Client.triggerServer("CEF::SERVER:ON_OPEN_BUSINESS_WINDOW", params.id)
        Client.callProcServer<string>("RPC::CEF::SERVER:GetProductsBusiness", params.id).then(data=>{
            const incomingItems: IncomingItemBusiness[] = JSON.parse(data);
            let _cars: CarType[] = [];
            incomingItems.map(incomingItem =>{
                _cars = [..._cars,{price: incomingItem.Price, VehicleType: ServerData.vehiclesTypes.find(v=>v.Id === incomingItem.ItemId)}];
            })
            setCars(_cars)
            let _listCars: {name: string, value: string}[] = [];
            _cars.map(car=>{
                _listCars =  [..._listCars, {name: car.VehicleType!.Mark + " " + car.VehicleType!.Model, value: car.VehicleType!.ModelHash!}]
            })
            setListCars(_listCars);
        })
    },[])

    const handleClickSetCurrentCar = (name: string,value: string) => {
        const car: CarType = cars.find(c=>c.VehicleType?.ModelHash === value)!;
        setCurrentCar(car)
        Client.triggerServer("CEF::SERVER:SELECT_CAR_IN_CARDEALERSHIP", Number(params.id), value);
    }
    const handleClickClose = () =>{
        Client.closeWindow();
        Client.triggerServer("CEF::SERVER:ON_EXIT_CARDEALERSHIP");
    }
    const handleClickBuy = () => {
        Client.triggerServer("CEF::SERVER:ON_BUY_CAR", Number(params.id), currentCar!.VehicleType!.Id, currentColor?.hexColor);
    }

    const handleClickPickColor = (index: number, hexColor?: string) => {
        setCurrentColor({index: index, hexColor: hexColor})
        Client.triggerServer("CEF::SERVER:ON_PICK_COLOR_CARDEALEARSHIP", hexColor);
    }
    const getTypeGasById = (id: number | undefined): string => {
        switch (id){
            case 0:
                return "Eco"
            case 1:
                return "Premium"
            case 2:
                return "Lux"
            case 3:
                return "Electric"
            default:
                return "Неизвестно"
        }
    }

    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', justifyContent: 'space-between'}}>
            <ReverseList onClick={handleClickSetCurrentCar} data={listCars}/>
            <Button type={"primary"} size={"large"} style={{marginTop: '80vh', width: '12vw'}} onClick={handleClickClose}>Выйти</Button>
            {currentCar &&
                <Space direction={"vertical"}>
                    <ReverseColorPicker width={300} onPickColor={handleClickPickColor}/>
                    <Card style={{display: 'flex', flexDirection: 'row', flexWrap: 'wrap'}}>
                        <Space direction={"vertical"} style={{width: 300}}>
                            <Title level={4}>Характеристики</Title>
                            <Space>
                                <Text type={"secondary"}>Цена:</Text>
                                <Text>{currentCar.price + '$'}</Text>
                            </Space>
                            <Space>
                                <Text type={"secondary"}>Кол-во посадочных мест:</Text>
                                <Text>{currentCar.VehicleType?.CountPassengersCapacity}</Text>
                            </Space>
                            <Space>
                                <Text type={"secondary"}>Вместимость багажника:</Text>
                                <Text>{currentCar.VehicleType?.BaggageHoldCapacity + ' кг'}</Text>
                            </Space>
                            <Space>
                                <Text type={"secondary"}>Расход топлива:</Text>
                                <Text>{currentCar.VehicleType?.FuelConsumption}</Text>
                            </Space>
                            <Space>
                                <Text type={"secondary"}>Тип топлива:</Text>
                                <Text>{getTypeGasById(currentCar.VehicleType?.GasType)}</Text>
                            </Space>
                        </Space>
                        <Divider/>
                        <Space style={{justifyContent: 'space-between', width: '100%'}}>
                            <Button type={"primary"} onClick={handleClickBuy}>Купить</Button>
                            <Button>Тест драйв</Button>
                        </Space>
                    </Card>
                </Space>
            }
        </Space>
    );
};

export default CarDealership;