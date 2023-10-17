import React from 'react';
import {Config} from "../../conf";
import {Button, Card, Space} from "antd";
import {CloseOutlined} from "@ant-design/icons";
import {Client} from "../../requests/Client";

const GasStation: React.FC = () => {
    return (
        <Space style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <Card title={"Заправка"} extra={<Button icon={<CloseOutlined/>} onClick={()=>Client.closeWindow()}/>}>

            </Card>
        </Space>
    );
};

export default GasStation;