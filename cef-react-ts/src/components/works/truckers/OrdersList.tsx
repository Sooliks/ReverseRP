import React, {useState} from 'react';
import {Button, Card, Space} from "antd";
import {Config} from "../../../conf";
import {CloseOutlined} from "@ant-design/icons";
import {Client} from "../../../requests/Client";


type OrderType = {
    Id: number
    BusinessName: string
    Count: number
    NameItem: string
}

const OrdersList: React.FC = () => {
    const [orders,setOrders] = useState<OrderType[]>([])

    return (
        <Space style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <Card title={"Заказы"} extra={<Button icon={<CloseOutlined/>} onClick={()=>Client.closeWindow()}/>}>
                <div style={{width: '58vw', height: 560}}>

                </div>
            </Card>
        </Space>
    );
};

export default OrdersList;