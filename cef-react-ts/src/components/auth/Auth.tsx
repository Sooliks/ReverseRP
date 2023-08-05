import React, {useState} from 'react';
import {Card, Menu, MenuProps, Space} from "antd";
import {Config} from "../../conf";

// @ts-ignore
import background from'../../assets/images/background_auth.png';
import Login from "./Login";
import Registration from "./Registration";

const Auth : React.FC = () => {
    const items: MenuProps['items'] = [
        {
            label: 'Вход',
            key: 'login',
        },
        {
            label: 'Регистрация',
            key: 'registration',
        },
    ]
    const [current, setCurrent] = useState('login');
    const onClick: MenuProps['onClick'] = (e) => {
        setCurrent(e.key);
    };

    return (
        <Space style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, backgroundImage:`url('${background}')`, justifyContent: 'center'}}>
            <Card style={{width: 800, height: 600}}>
                <Space direction={"vertical"} style={{width: '100%', height: '100%', alignItems: 'center'}}>
                    <Menu style={{width: 200, justifyContent: 'center'}} onClick={onClick} selectedKeys={[current]} mode="horizontal" items={items} />
                    <Space align={"center"} style={{width: '100%', height: 450, justifyContent: 'center'}}>
                        {current === 'login' && <Login/>}
                        {current === 'registration' && <Registration/>}
                    </Space>
                </Space>
            </Card>
        </Space>
    );
};

export default Auth;