import React, {useEffect, useState} from 'react';
import {Button, Card, Space, Typography} from "antd";
import {Config} from "../../../conf";
import {CloseOutlined} from "@ant-design/icons";
import {Client} from "../../../requests/Client";
import {ColumnsType} from "antd/es/table";
import {Table} from "antd/lib";


type OrderType = {
    Id: number
    BusinessName: string
    Count: number
    NameItem: string
}
const {Text,Link} = Typography;
const OrdersList: React.FC = () => {
    const columns: ColumnsType<OrderType> = [
        {
            title: 'Заказчик',
            dataIndex: 'BusinessName',
            key: 'BusinessName',
            render: (_, record) => (
                <Space size="middle">
                    <Text>{record.BusinessName}</Text>
                </Space>
            ),
        },
        {
            title: 'Кол-во',
            dataIndex: 'Count',
            key: 'Count',
            render: (_, record) => (
                <Space size="middle">
                    <Text>{record.Count + ' шт.'}</Text>
                </Space>
            ),
        },
        {
            title: 'Товар',
            dataIndex: 'NameItem',
            key: 'NameItem',
            render: (_, record) => (
                <Space size="middle">
                    <Text>{record.NameItem}</Text>
                </Space>
            ),
        },
        {
            title: 'Действие',
            dataIndex: 'action',
            key: 'action',
            render: (_, record) => (
                <Space size="middle">
                    <Button>Взять заказ</Button>
                </Space>
            ),
        },
    ];
    const [orders,setOrders] = useState<OrderType[]>([
        {Id: 0, Count: 455, NameItem: 'Бургер', BusinessName: 'Маркет 24/7'}
    ])
    useEffect(()=>{

    },[])

    return (
        <Space style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <Card extra={<Button icon={<CloseOutlined/>} onClick={()=>Client.closeWindow()}/>}>
                <div style={{width: '58vw', height: 560}}>
                    <Table columns={columns} dataSource={orders}/>
                </div>
            </Card>
        </Space>
    );
};

export default OrdersList;