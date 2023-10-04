import React, {useState} from 'react';
import {Button, Col, InputNumber, Row, Slider, Space} from "antd";
import {ItemType} from "./Item";
import {Client} from "../../requests/Client";

type ItemManagerProps = {
    item: ItemType

}


const ItemManager: React.FC<ItemManagerProps> = ({item}) => {

    const [inputValue, setInputValue] = useState<number | null>(1);

    const onChange = (newValue: number | null) => {
        setInputValue(newValue);
    };

    const handleClickSlice = () => {

    }
    const handleClickUse = () => {
        Client.triggerServer("CEF::SERVER:USE_ITEM", item.id)
    }
    const handleClickDrop = () =>{
        Client.triggerServer("CEF::SERVER:DROP_ITEM", item.id, inputValue)
    }

    return (
        <Space>
            <Row>
                <Col span={12}>
                    <Slider
                        style={{width:84}}
                        min={0}
                        max={item.count}
                        onChange={onChange}
                        value={typeof inputValue === 'number' ? inputValue : 0}
                    />
                </Col>
                <Col span={4}>
                    <InputNumber
                        style={{ margin: '0 10px'}}
                        min={0}
                        max={item.count}
                        value={inputValue}
                        onChange={onChange}
                    />
                </Col>
            </Row>
            <Button onClick={handleClickSlice}>Разделить</Button>
            <Button onClick={handleClickUse}>Использовать</Button>
            <Button onClick={handleClickDrop}>Выкинуть</Button>
        </Space>
    );
};

export default ItemManager;