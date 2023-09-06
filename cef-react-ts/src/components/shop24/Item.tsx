import React, {useEffect, useState} from 'react';
import {ItemType} from "./Market";
import {Button, Space, Typography} from "antd";

const {Text} = Typography;

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
        <Space align={"center"} direction={"vertical"} style={{border: '1px solid #f0f0f0', padding: 10, width: 90, borderRadius: '4px'}}>
            <img width={84} height={84} src={image} alt={item.label}/>
            <Space direction={"vertical"}>
                <Text type={"secondary"} style={{width: 84}} ellipsis>{item.label}</Text>
                <Text style={{width: 84}} ellipsis>{'Цена: ' + item.price + '$'}</Text>
                <Button size={"small"} style={{width: 84}}>Купить</Button>
            </Space>
        </Space>
    );
};

export default Item;