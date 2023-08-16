import React from 'react';
import {Card, Space, Typography} from "antd";
import {Config} from "../../conf";
import Keys from "./Keys";



const {Title} = Typography;


const Hud : React.FC = () => {

    return (
        <Space align={"start"} style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute',justifyContent: 'space-between'}}>
            <Space align={"center"} style={{marginLeft:20, height: Config.screenResolution.height,}}>
                <Keys/>
            </Space>
            <Space align={"start"}>
                <Card style={{width: 200}}>
                    <Title level={5} style={{margin: 0, textAlign: 'center'}} type={"secondary"}>Reverse Role Play</Title>
                </Card>
            </Space>
        </Space>
    );
};

export default Hud;