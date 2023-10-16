import React, {useEffect, useState} from 'react';
import {Card, Space, Typography} from "antd";
import {Config} from "../../conf";
import Keys from "./Keys";
import {CreditCardOutlined, DollarOutlined} from "@ant-design/icons";
import {Client} from "../../requests/Client";



const {Title, Text} = Typography;


type IncomingInfoHudType = {
    money: number
    moneyBank: number
}

const Hud : React.FC = () => {

    const[data,setData] = useState<IncomingInfoHudType>({money: 0, moneyBank: 0})
    mp.events.add("SERVER::CEF:UPDATE_HUD",(args)=>{
        args = JSON.parse(args);
        setData(args[0])
    })
    useEffect(()=>{
        Client.callProcServer<string>("RPC::CEF::SERVER:GET_INFO_CHARACTER").then(data=>{
            setData(JSON.parse(data))
        })
    },[])

    return (
        <Space align={"end"} style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute',justifyContent: 'space-between'}}>
            <Space align={"center"} style={{marginLeft:20, height: Config.screenResolution.height,}}>
                <Keys/>
            </Space>
            <Space align={"end"}>
                <Card style={{width: 200}}>
                    <Space direction={"vertical"}>
                        <Text><DollarOutlined /> {' '+data.money + '$'}</Text>
                        <Text><CreditCardOutlined /> {' '+data.moneyBank + '$'}</Text>
                    </Space>
                </Card>
            </Space>
        </Space>
    );
};

export default Hud;