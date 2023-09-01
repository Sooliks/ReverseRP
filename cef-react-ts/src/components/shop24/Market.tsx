import React, {useState} from 'react';
import {Config} from "../../conf";
import background from "../../assets/images/background_auth.png";
import {Card, Menu, MenuProps, Space} from "antd";
import {ShoppingCartOutlined, ToolOutlined} from "@ant-design/icons";

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
                <Space style={{width: 1100, height: 700}} align={"start"}>
                    <Menu style={{width: 1100}} onClick={onClickMenu} selectedKeys={[current]} mode="horizontal" items={items} />
                </Space>
            </Card>
        </Space>
    );
};

export default Market;