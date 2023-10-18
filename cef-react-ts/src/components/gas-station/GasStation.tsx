import React, {useEffect, useState} from 'react';
import {Config} from "../../conf";
import {Button, Card, Col, Divider, InputNumber, Row, Slider, Space, Statistic, Typography} from "antd";
import {CloseOutlined} from "@ant-design/icons";
import {Client} from "../../requests/Client";
import {useParams} from "react-router-dom";
import {IncomingItemBusiness} from "../../types/businessesTypes";


const {Text} = Typography;

type GasType = {
    typeGas: string
    price: number
}
type GasStationParams = {
    id: string
}

const GasStation: React.FC = () => {
    const params = useParams<GasStationParams>();

    const [inputValue, setInputValue] = useState<number | null>(1);
    const [currentGas,setCurrentGas] = useState<GasType>({typeGas: 'Eco', price: 30})
    const [maxFuel, setMaxFuel] = useState<number>(20);

    const[gasProperties,setGasProperties] = useState<GasType[]>([
        {typeGas: 'Eco', price: 30},
        {typeGas: 'Premium', price: 40},
        {typeGas: 'Lux', price: 50},
        {typeGas: 'Electric', price: 27},
    ])

    useEffect(()=>{
        Client.triggerServer("CEF::SERVER:ON_OPEN_BUSINESS_WINDOW", params.id)
        Client.callProcServer<string>("RPC::CEF::SERVER:GetProductsBusiness", params.id).then(data=>{
            const incomingItems: IncomingItemBusiness[] = JSON.parse(data);
            setGasProperties([
                {typeGas: 'Eco', price: incomingItems[0].Price},
                {typeGas: 'Premium', price: incomingItems[1].Price},
                {typeGas: 'Lux', price: incomingItems[2].Price},
                {typeGas: 'Electric', price: incomingItems[3].Price}
            ])
        })
    },[])

    const handleClickBuy = () => {

    }

    return (
        <Space style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <Card title={"Заправка"} extra={<Button icon={<CloseOutlined/>} onClick={()=>Client.closeWindow()}/>}>
                <div style={{width: '50vw', height: '50vh'}}>
                    <div style={{display: 'flex', justifyContent: 'space-around', flexDirection: 'row'}}>
                        {gasProperties.map(gas=>
                            <Button autoFocus={currentGas === gas} onClick={()=>setCurrentGas(gas)} style={{height: 150, width: 145, fontSize: '15px'}}>{gas.typeGas + ' '+ gas.price + (gas.typeGas === 'Electric' ? '$/кв' : '$/л')}</Button>
                        )}
                    </div>
                    <Divider type={"horizontal"}/>
                    <div style={{display: 'flex', flexDirection: 'row', width: '100%'}}>
                        <Slider
                            min={1}
                            max={maxFuel}
                            onChange={(v)=>setInputValue(v)}
                            value={typeof inputValue === 'number' ? inputValue : 0}
                            style={{width: '97%'}}
                        />
                        <InputNumber
                            min={maxFuel === 0 ? 0 : 1}
                            max={maxFuel}
                            value={inputValue}
                            onChange={(v)=>setInputValue(v)}
                            style={{marginLeft: 16}}
                        />
                    </div>
                    <div style={{height: '50%',display: 'flex', flexDirection: 'column', justifyContent:'space-between'}}>
                        <Statistic title="Итого: " value={currentGas.price * inputValue! + '$'} precision={2} />
                        <Button size={"large"} type={"primary"} style={{width: '100%'}}>Заправить</Button>
                    </div>
                </div>
            </Card>
        </Space>
    );
};

export default GasStation;