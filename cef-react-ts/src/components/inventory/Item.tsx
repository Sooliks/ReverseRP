import React from 'react';
import {Space} from "antd";

export type ItemType = {
    id: number
    name: string
    description: string
    count: number
}


const Item: React.FC<ItemType> = ({id, name, description, count}) => {
    return (
        <Space>
            gf
        </Space>
    );
};

export default Item;