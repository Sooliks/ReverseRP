import React, {useEffect, useState} from 'react';
import {Space, Tooltip, Typography} from "antd";


const {Text} = Typography;

export type ItemType = {
    id: number
    name: string
    description: string
    count: number
}


const Item: React.FC<ItemType> = ({id, name, description, count}) => {
    
    const [image,setImage] = useState()
    /*try {
        image = require('../../assets/images/inventory' + 'item_' + id + '.png');
    }catch (e) {

    }*/
    useEffect(()=>{
        try {
            setImage(require('../../assets/images/inventory/' + 'item_' + id + '.png'))
        }catch (e) {
            
        }
    })


    return (
        <Space direction={"vertical"} style={{width:84,height:84}} align={"center"}>
            <Space style={{border: '1px gray'}} direction={"vertical"}>
                <img width={84} height={80} src={image} alt={name}/>
            </Space>
            <Text type={"secondary"}>{count}</Text>
        </Space>
    );
};

export default Item;