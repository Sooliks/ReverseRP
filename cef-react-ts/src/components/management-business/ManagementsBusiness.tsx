import React, {useState} from 'react';
import {Config} from "../../conf";
import {Card, Menu, MenuProps, Space} from "antd";
import {ShoppingCartOutlined, ToolOutlined} from "@ant-design/icons";

const ManagementsBusiness: React.FC = () => {

    const [current,setCurrent] = useState<string>('statistics');

    const onClickMenu: MenuProps['onClick'] = (e) => {
        console.log('click ', e);
        setCurrent(e.key);
    };
    const items: MenuProps['items'] = [
        {
            label: 'Статистика',
            key: 'statistics',
            icon: <ShoppingCartOutlined />,
        },
        {
            label: 'Товары',
            key: 'products',
            icon: <ToolOutlined />,
        },
    ]

    return (
        <Space style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <Card title={"Управление бизнесом"}>
                <div style={{width: '60vw', height: '70vh'}}>
                    <Menu onClick={onClickMenu} selectedKeys={[current]} mode="horizontal" items={items} />
                </div>
            </Card>
        </Space>
    );
};

export default ManagementsBusiness;