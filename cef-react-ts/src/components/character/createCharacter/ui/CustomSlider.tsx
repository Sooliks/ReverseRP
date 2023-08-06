import React from 'react';
import {Slider, Space, Typography} from "antd";

const {Text} = Typography;

type CustomSliderType = {
    text?: string
    onChange: (value: number) => void
    min: number
    max: number
    style?: React.CSSProperties
    step?: number
    tooltipVisible?: boolean
    defaultValue?: number
}


const CustomSlider: React.FC<CustomSliderType> = ({text,onChange, min, max, style, step, tooltipVisible , defaultValue}) => {
    return (
        <Space direction={"vertical"} style={{...style, margin: 10}}>
            <Text>{text}</Text>
            <Slider
                onChange={(value)=>onChange(value)}
                min={min}
                max={max}
                step={step}
                tooltip={{open: tooltipVisible}}
                defaultValue={defaultValue}
            />
        </Space>
    );
};

export default CustomSlider;