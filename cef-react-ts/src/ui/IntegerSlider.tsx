import React, {useState} from 'react';
import {Col, InputNumber, Row, Slider} from "antd";


type IntegerSliderProps = {
    onChange: (value: number | null) => void
    value: number | null
}

const IntegerSlider: React.FC<IntegerSliderProps> = ({onChange, value}) => {

    const [inputValue, setInputValue] = useState<number | null>(typeof value === 'number' ? value : 0);
    const handleChange = (newValue: number | null) => {
        setInputValue(newValue);
        onChange(newValue);
    };


    return (
        <Row>
            <Col span={12}>
                <Slider
                    min={1}
                    max={20}
                    onChange={handleChange}
                    value={typeof inputValue === 'number' ? inputValue : 0}
                />
            </Col>
            <Col span={4}>
                <InputNumber
                    min={1}
                    max={20}
                    style={{ margin: '0 16px' }}
                    value={inputValue}
                    onChange={handleChange}
                />
            </Col>
        </Row>
    );
};

export default IntegerSlider;