import React, {DragEventHandler, useEffect, useState} from 'react';
import {Popover, Space, Tooltip, Typography} from "antd";
import {BoardType} from "./Board";
import ItemManager from "./ItemManager";




export type ItemType = {
    id: number
    index: number
    name: string
    description: string
    count: number
    currentBoard?: BoardType
}

type ItemProps = {
    item: ItemType
}


const Item: React.FC<ItemProps> = ({item}) => {

    const [image,setImage] = useState<string>('../../assets/images/inventory/' + 'item_' + item.id + '.png')
    useEffect(()=>{
        try {
            setImage(require('../../assets/images/inventory/' + 'item_' + item.id + '.png'))
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
            <Tooltip title={`${item.name} ${item.count} шт.`}>
                <Popover placement="topLeft" title={item.name} content={<ItemManager item={item}/>} trigger="click">
                    <Space style={{border: '1px gray', margin: 0}} direction={"vertical"}>
                        <img width={84} height={84} src={image} alt={item.name}/>
                    </Space>
                </Popover>
            </Tooltip>
        </Space>
    );
};

export default Item;