import React from 'react';
import {Button, Space} from "antd";


type SettingsProps = {
    onClickGps: () => void
    onClickParking: () => void
}

const Settings: React.FC<SettingsProps> = ({onClickGps, onClickParking}) => {
    return (
        <Space direction={"vertical"} style={{width: '100%', height: '100%'}}>
            <Button onClick={onClickGps}>Отметить на GPS</Button>
            <Button onClick={onClickParking}>Отправить на парковку</Button>
        </Space>
    );
};

export default Settings;