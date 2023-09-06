import React, {useState} from 'react';
import {Config} from "../../conf";
import background from "../../assets/images/background_auth.png";
import {Card, Menu, MenuProps, Space} from "antd";
import {ShoppingCartOutlined, ToolOutlined} from "@ant-design/icons";
import Item from "./Item";

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
const listItems: ItemType[] = [
    {id: 0, type: ItemTypeEnum.Products, price: 150, label: 'Бургер', description: 'Восполняет 50 еды'}
]


const Market: React.FC = () => {
    const [current,setCurrent] = useState<string>('products');

    const onClickMenu: MenuProps['onClick'] = (e) => {
        console.log('click ', e);
        setCurrent(e.key);
    };
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

    return (
        <Space style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <Card>
                <Space style={{width: 1100, height: 700}} align={"start"} direction={"vertical"}>
                    <Menu style={{width: 1100}} onClick={onClickMenu} selectedKeys={[current]} mode="horizontal" items={items} />
                    <Space wrap>
                        {current === "products" && listItems.filter(i=>i.type === ItemTypeEnum.Products).map(i=>
                            <Item item={i}/>
                        )}
                        {current === "tools" && listItems.filter(i=>i.type === ItemTypeEnum.Tools).map(i=>
                            <Item item={i}/>
                        )}
                    </Space>
                </Space>
            </Card>
        </Space>
    );
};

export default Market;