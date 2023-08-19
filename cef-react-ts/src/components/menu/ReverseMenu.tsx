import React, {useState} from 'react';
import {MenuProps, Space} from "antd";
import {Config} from "../../conf";
import { Menu } from 'antd';
import {CodeSandboxOutlined, SettingOutlined, UserOutlined} from "@ant-design/icons";
import Profile from "./pages/Profile";
import Cases from "./pages/Cases";
import Settings from "./pages/Settings";

const ReverseMenu: React.FC = () => {
    const items: MenuProps['items'] = [
        {
            label: 'Профиль',
            key: 'profile',
            icon: <UserOutlined />
        },
        {
            label: 'Кейсы',
            key: 'cases',
            icon: <CodeSandboxOutlined />
        },
        {
            label: 'Настройки',
            key: 'settings',
            icon: <SettingOutlined />
        },
    ]
    const [current, setCurrent] = useState('profile');
    const onClick: MenuProps['onClick'] = (e) => {
        setCurrent(e.key);
    };

    return (
        <div style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', backgroundColor: 'white'}}>
            <Menu onClick={onClick} selectedKeys={[current]} mode="horizontal" items={items}  />
            {current === 'profile' && <Profile/>}
            {current === 'cases' && <Cases/>}
            {current === 'settings' && <Settings/>}
        </div>
    );
};

export default ReverseMenu;