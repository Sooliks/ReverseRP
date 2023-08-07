import React, {useState} from 'react';
import {Button, Space, Typography} from "antd";
import {LeftOutlined, RightOutlined} from "@ant-design/icons";


const {Title, Text} = Typography;

export type DataTypeSwitcher = {
    value: number
    placeHolder: string,
}

type SwitcherType = {
    data: DataTypeSwitcher[]
    onChange: (currentValue: number) => void
    width?: number
    text?: string
}

const Switcher: React.FC<SwitcherType> = ({data,onChange,width,text}) => {
    const [currentValue,setCurrentValue] = useState<number>(0)
    const handleClickLeft = () =>{
        if(currentValue!==0){
            setCurrentValue(prev=>prev-1)
            onChange(data[currentValue-1].value);
        }
    }
    const handleClickRight = () =>{
        if(currentValue!==data.length-1){
            setCurrentValue(prev=>prev+1)
            onChange(data[currentValue+1].value);
        }
    }

    return (
        <Space direction={"vertical"}>
            <Typography.Title level={5} style={{textAlign: 'center', margin: 0}}>
                {text}
            </Typography.Title>
            <Space align={"start"} style={{justifyContent: 'space-between', width: width === undefined ? 280 : width, marginLeft: 10, marginRight: 10}}>
                <Button disabled={currentValue===0} icon={<LeftOutlined />} onClick={handleClickLeft}/>
                <div style={{border: '1px solid #d9d9d9', width: 200, height: 30, display: "flex", flexDirection: "column", justifyContent: 'center'}}>
                    <Text style={{textAlign: 'center', margin: 0}}>
                        {data[currentValue].placeHolder}
                    </Text>
                </div>
                <Button disabled={currentValue===data.length-1} icon={<RightOutlined />} onClick={handleClickRight}/>
            </Space>
        </Space>
    );
};

export default Switcher;