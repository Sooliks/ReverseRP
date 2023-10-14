import React from 'react';
import {useParams} from "react-router-dom";
import {Config} from "../../conf";
import {Button, Card, Space} from "antd";
import {CloseOutlined} from "@ant-design/icons";
import {Client} from "../../requests/Client";
import Information from "../../ui/Information";

type InformationOfBusinessParams = {
    id: string
}


const InformationOfBusiness: React.FC = () => {
    const params = useParams<InformationOfBusinessParams>();

    return (
        <Space style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <Card title={"Информация"} extra={<Button icon={<CloseOutlined/>} onClick={()=>Client.closeWindow()}/>}>
                <div style={{width: '60vw', height: '60vh'}}>
                    <Information text={["Гос цена: "]} data={["2000000"]}/>
                </div>
            </Card>
        </Space>
    );
};

export default InformationOfBusiness;