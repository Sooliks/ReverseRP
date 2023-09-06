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
        <div style={{width: 80, height: 100, border: '1px gray'}}>
            <img width={84} height={84} src={image} alt={item.label}/>
            <Space>
                <Button>Купить</Button>
                <Text>{item.price + '$'}</Text>
            </Space>
        </div>
    );
};

export default Item;