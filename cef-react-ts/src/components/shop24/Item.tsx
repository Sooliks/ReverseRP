import React, {useEffect, useState} from 'react';
import {ItemType} from "./Market";
import {Button, Space, Typography} from "antd";
import {Client} from "../../requests/Client";

const {Text} = Typography;

type ItemProps = {
    item: ItemType
    idMarket: number
}


const Item: React.FC<ItemProps> = ({item,idMarket}) => {

    const [image,setImage] = useState<string>('../../assets/images/inventory/' + 'item_' + item.id + '.png')
    useEffect(()=>{
        try {
            setImage(require('../../assets/images/inventory/' + 'item_' + item.id + '.png'))
        }catch (e) {
            setImage(require('../../assets/images/not_found_image.jpg'));
        }
    })
    const handleClickOnBuy = () => {
        Client.triggerServer("CEF::SERVER:ON_BUY_ITEM", idMarket, item.id, item.type);
    }

    return (
        <Space align={"center"} direction={"vertical"} style={{border: '1px solid #f0f0f0', padding: 10, width: 90, borderRadius: '4px'}}>
            <img width={84} height={84} src={image} alt={item.label}/>
            <Space direction={"vertical"}>
                <Text style={{width: 84}} ellipsis>{item.label}</Text>
                <Text style={{width: 84}} ellipsis type={"secondary"}>
                    Цена: {' '}
                    <Text>{item.price + '$'}</Text>
                </Text>
                <Button size={"small"} style={{width: 84}} onClick={handleClickOnBuy}>Купить</Button>
            </Space>
        </Space>
    );
};

export default Item;