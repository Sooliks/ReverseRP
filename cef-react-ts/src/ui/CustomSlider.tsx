import React from 'react';
import {Slider, Space, Typography} from "antd";
import {SliderBaseProps} from "antd/es/slider";

const {Text} = Typography;

type CustomSliderType = {
    text?: string
    onChange: (value: number) => void
    min: number
    max: number
    style?: React.CSSProperties
    step?: number
    defaultValue?: number,
    tooltipVisible?: boolean
    formatterWork?: boolean
}


const CustomSlider: React.FC<CustomSliderType> = ({formatterWork,text,onChange, min, max, style, step, tooltipVisible , defaultValue}) => {
    const formatter = (value: number | undefined) => {
        if(!formatterWork)return value;
        if(value === max){
            return 'Нету'
        }
        else{
            return value
        }
    };

    return (
        <Space direction={"vertical"} style={{...style, margin: 10}}>
            <Text>{text}</Text>
            <Slider
                onChange={(value)=>onChange(value)}
                min={min}
                max={max}
                step={step}
                tooltip={{formatter, open: tooltipVisible}}
                defaultValue={defaultValue}
            />
        </Space>
    );
};

export default CustomSlider;