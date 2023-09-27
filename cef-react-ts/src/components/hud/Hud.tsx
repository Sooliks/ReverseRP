import React from 'react';
import {Card, Space, Typography} from "antd";
import {Config} from "../../conf";
import Keys from "./Keys";
import {CreditCardOutlined, DollarOutlined} from "@ant-design/icons";



const {Title, Text} = Typography;


const Hud : React.FC = () => {

    return (
        <Space align={"end"} style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute',justifyContent: 'space-between'}}>
            <Space align={"center"} style={{marginLeft:20, height: Config.screenResolution.height,}}>
                <Keys/>
            </Space>
            <Space align={"end"}>
                <Card style={{width: 200}}>
                    <Space direction={"vertical"}>
                        <Text><DollarOutlined /></Text>
                        <Text><CreditCardOutlined /></Text>
                    </Space>
                </Card>
            </Space>
        </Space>
    );
};

export default Hud;