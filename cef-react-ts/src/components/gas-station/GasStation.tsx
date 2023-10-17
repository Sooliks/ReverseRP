import React, {useState} from 'react';
import {Config} from "../../conf";
import {Button, Card, Col, Divider, InputNumber, Row, Slider, Space, Typography} from "antd";
import {CloseOutlined} from "@ant-design/icons";
import {Client} from "../../requests/Client";


const {Text} = Typography;

type GasType = {
    typeGas: string
    price: number
}

const GasStation: React.FC = () => {
    const [inputValue, setInputValue] = useState<number | null>(1);
    const [currentGas,setCurrentGas] = useState<GasType>({typeGas: 'Eco', price: 30})
    const [maxFuel, setMaxFuel] = useState<number>(20);

    const[gasProperties,setGasProperties] = useState<GasType[]>([
        {typeGas: 'Eco', price: 30},
        {typeGas: 'Premium', price: 40},
        {typeGas: 'Lux', price: 50},
        {typeGas: 'Electric', price: 27},
    ])

    return (
        <Space style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <Card title={"Заправка"} extra={<Button icon={<CloseOutlined/>} onClick={()=>Client.closeWindow()}/>}>
                <div style={{width: '50vw', height: '55vh'}}>
                    <div style={{display: 'flex', justifyContent: 'space-around', flexDirection: 'row'}}>
                        {gasProperties.map(gas=>
                            <Button autoFocus={currentGas === gas} onClick={()=>setCurrentGas(gas)} style={{height: 150, width: 145, fontSize: '15px'}}>{gas.typeGas + ' '+ gas.price + '$/л'}</Button>
                        )}
                    </div>
                    <Divider type={"horizontal"}/>
                    <div style={{display: 'flex', flexDirection: 'row', width: '100%'}}>
                        <Slider
                            min={1}
                            max={maxFuel}
                            onChange={(v)=>setInputValue(v)}
                            value={typeof inputValue === 'number' ? inputValue : 0}
                            style={{width: '100%'}}
                        />
                        <InputNumber
                            min={1}
                            max={maxFuel}
                            style={{margin: '0 16px'}}
                            value={inputValue}
                            onChange={(v)=>setInputValue(v)}
                        />

                    </div>
                    <div>
                        <Button style={{width: '100%'}}>Заправить</Button>
                    </div>
                </div>
            </Card>
        </Space>
    );
};

export default GasStation;