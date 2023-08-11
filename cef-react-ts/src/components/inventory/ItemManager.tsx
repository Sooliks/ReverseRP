import React, {useState} from 'react';
import {Button, Col, InputNumber, Row, Slider, Space} from "antd";
import {ItemType} from "./Item";

type ItemManagerProps = {
    count: number

}


const ItemManager: React.FC<ItemManagerProps> = ({count}) => {

    const [inputValue, setInputValue] = useState<number | null>(0);

    const onChange = (newValue: number | null) => {
        setInputValue(newValue);
    };

    return (
        <Space>
            <Row>
                <Col span={12}>
                    <Slider
                        style={{width:84}}
                        min={0}
                        max={count}
                        onChange={onChange}
                        value={typeof inputValue === 'number' ? inputValue : 0}
                    />
                </Col>
                <Col span={4}>
                    <InputNumber
                        style={{ margin: '0 10px'}}
                        min={0}
                        max={count}
                        value={inputValue}
                        onChange={onChange}
                    />
                </Col>
            </Row>
            <Button>Разделить</Button>
        </Space>
    );
};

export default ItemManager;