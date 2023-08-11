import React, {DragEventHandler, useEffect, useState} from 'react';
import {Popover, Space, Tooltip, Typography} from "antd";
import {BoardType} from "./Board";
import ItemManager from "./ItemManager";


const {Text} = Typography;

export type ItemType = {
    id: number
    index: number
    name: string
    description: string
    count: number
    currentBoard?: BoardType
}


const Item: React.FC<ItemType> = ({id, name, description, count}) => {

    const [image,setImage] = useState()
    useEffect(()=>{
        try {
            setImage(require('../../assets/images/inventory/' + 'item_' + id + '.png'))
        }catch (e) {
            setImage(require('../../assets/images/not_found_image.jpg'));
        }
    })

    return (
        <Space
            direction={"vertical"}
            style={{width:84,height:84, cursor: 'grab'}}
            align={"center"}
        >
            <Tooltip title={`${name} ${count} шт.`}>
                <Popover placement="topLeft" title={name} content={<ItemManager count={count}/>} trigger="click">
                    <Space style={{border: '1px gray', margin: 0}} direction={"vertical"}>
                        <img width={84} height={84} src={image} alt={name}/>
                    </Space>
                </Popover>
            </Tooltip>
        </Space>
    );
};

export default Item;