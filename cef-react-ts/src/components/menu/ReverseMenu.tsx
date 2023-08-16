import React, {useState} from 'react';
import {MenuProps, Space} from "antd";
import {Config} from "../../conf";
import { Menu } from 'antd';

const ReverseMenu: React.FC = () => {
    const items: MenuProps['items'] = [
        {
            label: 'Navigation One',
            key: 'mail',
        },
        {
            label: 'Navigation Two',
            key: 'app',
        },
    ]
    const [current, setCurrent] = useState('mail');
    const onClick: MenuProps['onClick'] = (e) => {
        setCurrent(e.key);
    };

    return (
        <div style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', backgroundColor: 'white'}}>
            <Menu onClick={onClick} selectedKeys={[current]} mode="horizontal" items={items}  />
        </div>
    );
};

export default ReverseMenu;