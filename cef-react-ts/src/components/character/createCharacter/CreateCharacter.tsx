import React, {useState} from 'react';
import {Button, Card, message, Space, Steps, theme} from "antd";
import {Config} from "../../../conf";
import {
    CheckOutlined,
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
import Finish from "./Steps/Finish";
import CreateCharacterContextProvider from "./context/CreateCharacterContextProvider";



const CreateCharacter: React.FC = () => {
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
        {
            title: '',
            content: <Finish/>,
            icon: <CheckOutlined />
        },
    ];
    const [current,setCurrent] = useState<number>(0)

    const handleClickFinish = () => {

    }


    return (
        <CreateCharacterContextProvider>
            <Space direction={"vertical"} style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height}}>
                <Card>
                    <Space style={{justifyContent: 'space-between', alignItems: 'center', width: '100%'}}>
                        <Steps style={{width: Config.screenResolution.width - 400}} items={steps} current={current}/>
                        <Space>
                            {current === steps.length - 1 && <Button type="primary" size={"large"} onClick={handleClickFinish}>Создать</Button>}
                            {current < steps.length - 1 && <Button type="primary" onClick={()=>setCurrent(prev=>prev+1)} size={"large"}>Дальше</Button>}
                            {current > 0 && <Button onClick={()=>setCurrent(prev=>prev-1)} size={"large"}>Назад</Button>}
                        </Space>
                    </Space>
                </Card>
                {steps[current].content}
            </Space>
        </CreateCharacterContextProvider>
    );
};

export default CreateCharacter;