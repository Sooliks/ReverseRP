import React, {useState} from 'react';
import {Button, Card, message, Space, Steps, theme} from "antd";
import {Config} from "../../../conf";
import {
    DeploymentUnitOutlined,
    HighlightOutlined,
    ScissorOutlined,
    SkinOutlined,
    SmileOutlined
} from "@ant-design/icons";
import Genetics from "./Steps/Genetics";
import Face from "./Steps/Face";
import Hair from "./Steps/Hair";
import SkinFeatures from "./Steps/SkinFeatures";
import Clothes from "./Steps/Clothes";



const CreateCharacter : React.FC = () => {
    const steps = [
        {
            title: 'Генетика',
            content: <Genetics/>,
            icon: <DeploymentUnitOutlined />,
        },
        {
            title: 'Форма лица',
            content: <Face/>,
            icon: <SmileOutlined />
        },
        {
            title: 'Волосы',
            content: <Hair/>,
            icon: <ScissorOutlined />
        },
        {
            title: 'Особенности кожи',
            content: <SkinFeatures/>,
            icon: <HighlightOutlined />
        },
        {
            title: 'Одежда',
            content: <Clothes/>,
            icon: <SkinOutlined />
        },
    ];
    const [current,setCurrent] = useState<number>(0)


    return (
        <Space direction={"vertical"} style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height}}>
            <Card>
                <Space style={{justifyContent: 'space-between', width: '100%', alignItems: 'center'}}>
                    <Steps style={{width: 1550}} items={steps} current={current}/>
                    <Space>
                        {current < steps.length - 1 && <Button type="primary" onClick={()=>setCurrent(prev=>prev+1)}>Дальше</Button>}
                        {current > 0 && <Button onClick={()=>setCurrent(prev=>prev-1)}>Назад</Button>}
                    </Space>
                </Space>
            </Card>

            <Card style={{width:330}}>
                {steps[current].content}
            </Card>
        </Space>
    );
};

export default CreateCharacter;