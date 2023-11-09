import React, {useEffect, useState} from 'react';
import {Config} from "../../conf";
import background from "../../assets/images/background_auth.png";
import {Button, Card, Menu, MenuProps, Space} from "antd";
import {CloseOutlined, ShoppingCartOutlined, ToolOutlined} from "@ant-design/icons";
import Item from "./Item";
import {useNavigate, useNavigation, useParams} from "react-router-dom";
import {Client} from "../../requests/Client";
import {IncomingItemBusiness} from "../../types/businessesTypes";

export type ItemType = {
    id: number
    label: string
    description: string
    type: ItemTypeEnum
    price: number
}

export enum ItemTypeEnum {
    Tools,
    Products
}
type MarketParams = {
    id: string
}


const Market: React.FC = () => {
    const params = useParams<MarketParams>();
    const [current,setCurrent] = useState<string>('products');

    const onClickMenu: MenuProps['onClick'] = (e) => {
        console.log('click ', e);
        setCurrent(e.key);
    };
    const[listMarketItems,setListMarketItems] = useState<ItemType[]>([
        {id: 0, type: ItemTypeEnum.Products, price: 150, label: 'Бургер', description: 'Восполняет 50 еды'}
    ])
    const items: MenuProps['items'] = [
        {
            label: 'Продукты',
            key: 'products',
            icon: <ShoppingCartOutlined />,
        },
        {
            label: 'Инструменты',
            key: 'tools',
            icon: <ToolOutlined />,
        },
    ]
    useEffect(()=>{
        Client.triggerServer("CEF::SERVER:ON_OPEN_BUSINESS_WINDOW", params.id)
        Client.callProcServer<string>("RPC::CEF::SERVER:GetProductsBusiness", params.id).then(data=>{
            const incomingItems: IncomingItemBusiness[] = JSON.parse(data);
            //TODO сделать получение айтемов с сервера
            setListMarketItems([
                {id: 0, type: ItemTypeEnum.Products, price: incomingItems[0].Price, label: 'Бургер', description: 'Восполняет 50 еды'},
            ])
        })
    },[])

    const handleClickClose = () => {
        Client.closeWindow();
    }

    return (
        <Space style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <Card>
                <Space style={{width: 1100, height: 700}} align={"start"} direction={"vertical"}>
                    <Space direction={"horizontal"}>
                        <Menu style={{width: 1050}} onClick={onClickMenu} selectedKeys={[current]} mode="horizontal" items={items} />
                        <Button icon={<CloseOutlined/>} onClick={handleClickClose}/>
                    </Space>
                    <Space wrap style={{overflowY: 'auto'}}>
                        {current === "products" && listMarketItems.filter(i=>i.type === ItemTypeEnum.Products).map(i=>
                            <Item item={i} idMarket={Number(params.id)}/>
                        )}
                        {current === "tools" && listMarketItems.filter(i=>i.type === ItemTypeEnum.Tools).map(i=>
                            <Item item={i} idMarket={Number(params.id)}/>
                        )}
                    </Space>
                </Space>
            </Card>
        </Space>
    );
};

export default Market;