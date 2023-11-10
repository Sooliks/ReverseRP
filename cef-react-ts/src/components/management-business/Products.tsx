import React, {useEffect, useState} from 'react';
import {Client} from "../../requests/Client";
import {ServerData} from "../../data/ServerData";
import {Space, Tag, Typography} from "antd";
import {ColumnsType} from "antd/es/table";
import {Table} from "antd/lib";



type ProductsProps = {
    idBusiness: number
}

type IncomingData = {
    items: ItemBusinessType[]
    businessType: "Маркет 24/7" | "Заправка" | "Автосалон высокого класса"
}

type ItemBusinessType = {
    itemId: number
    count: number
    price: number
}
type ProductType = {
    name: string
    itemBusiness: ItemBusinessType

}
const {Text,Link} = Typography;

const columns: ColumnsType<ProductType> = [
    {
        title: 'Название',
        dataIndex: 'name',
        key: 'name',
    },
    {
        title: 'Кол-во',
        dataIndex: 'count',
        key: 'count',
        render: (_, record) => (
            <Space size="middle">
                <Text>{record.itemBusiness.count + ' шт.'}</Text>
                <Link>Заказать</Link>
            </Space>
        ),
    },
    {
        title: 'Цена',
        dataIndex: 'price',
        key: 'price',
        render: (_, record) => (
            <Space size="middle">
                <Text>{record.itemBusiness.price + '$'}</Text>
                <Link>Изменить</Link>
            </Space>
        ),
    },
];

const Products: React.FC<ProductsProps> = ({idBusiness}) => {
    useEffect(()=>{
        Client.callProcServer<string>("RPC::CEF::SERVER:GetProductsBusiness", idBusiness).then(data => {
            console.log(data)
            const incomingData: IncomingData = JSON.parse(data);
            switch (incomingData.businessType) {
                case "Автосалон высокого класса":
                    Client.callProcServer<string>("RPC::CEF::SERVER:GetVehiclesTypes").then(data=>{
                        ServerData.vehiclesTypes = JSON.parse(data);
                        incomingData.items.map(item=>{
                            setProducts([...products,
                                {
                                    name: ServerData.vehiclesTypes.find(v=>v.Id == item.itemId)!.Mark,
                                    itemBusiness: item
                                }])
                        })
                    })
                    break
                case "Заправка":
                    break
                case "Маркет 24/7":
                    break
            }
        })
    },[])
    const [products,setProducts] = useState<ProductType[]>([])

    return (
        <div style={{width: '100%', height: '100%'}}>
            <Table columns={columns} dataSource={products}/>
        </div>
    );
};

export default Products;