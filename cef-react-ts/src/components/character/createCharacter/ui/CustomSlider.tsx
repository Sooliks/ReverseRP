import React from 'react';
import {Slider, Space, Typography} from "antd";

const {Text} = Typography;

type CustomSliderType = {
    text: string
    onChange: (value: number) => void
    min: number
    max: number
    style?: React.CSSProperties
    step?: number
    tooltipVisible?: boolean
    defaultValue: number
}


const CustomSlider: React.FC<CustomSliderType> = ({text,onChange, min= 1, max= 0, style, step= 0.1, tooltipVisible, defaultValue=0}) => {
    return (
        <Space direction={"vertical"} style={{...style, margin: 10}}>
            <Text>{text}</Text>
            <Slider
                onChange={(v)=>onChange(v)}
                min={min}
                max={max}
                step={step}
                tooltipVisible={tooltipVisible}
                defaultValue={defaultValue}
            />
        </Space>
    );
};

export default CustomSlider;