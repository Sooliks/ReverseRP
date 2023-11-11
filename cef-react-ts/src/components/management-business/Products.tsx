import React, {useEffect, useState} from 'react';
import {Client} from "../../requests/Client";
import {ServerData} from "../../data/ServerData";
import {Space, Tag, Typography} from "antd";
import {ColumnsType} from "antd/es/table";
import {Table} from "antd/lib";
import {IncomingItemBusiness} from "../../types/businessesTypes";
import ModalWithInputForm from "../../ui/ModalWithInputForm";

type ProductsProps = {
    idBusiness: number
}
type IncomingData = {
    items: IncomingItemBusiness[]
    businessType: "Маркет 24/7" | "Заправка" | "Автосалон высокого класса"
}
type ProductType = {
    name?: string
    itemBusiness: IncomingItemBusiness
}
const {Text,Link} = Typography;

const Products: React.FC<ProductsProps> = ({idBusiness}) => {
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
                    <Text>{record.itemBusiness.Count + ' шт.'}</Text>
                    <Link onClick={()=>{
                        setIsOpenModalOrder(true);
                        setCurrentItem(record.itemBusiness)
                    }}
                    >
                        Заказать
                    </Link>
                </Space>
            ),
        },
        {
            title: 'Цена',
            dataIndex: 'price',
            key: 'price',
            render: (_, record) => (
                <Space size="middle">
                    <Text>{record.itemBusiness.Price + '$'}</Text>
                    <Link
                        onClick={()=>{
                            setIsOpenModalPrice(true);
                            setCurrentItem(record.itemBusiness)
                        }}
                    >
                        Изменить
                    </Link>
                </Space>
            ),
        },
    ];

    useEffect(()=>{
        Client.callProcServer<string>("RPC::CEF::SERVER:GetProductsBusiness", idBusiness).then(data => {
            const incomingData: IncomingData = JSON.parse(data);
            let _products: ProductType[] = [];
            switch (incomingData.businessType) {
                case "Автосалон высокого класса":
                    Client.callProcServer<string>("RPC::CEF::SERVER:GetVehiclesTypes").then(data=>{
                        ServerData.vehiclesTypes = JSON.parse(data);
                        incomingData.items.map(item=>{
                            const veh = ServerData.vehiclesTypes.find(v=>v.Id == item.ItemId)
                            _products.push({
                                name: veh?.Mark + ' ' + veh?.Model,
                                itemBusiness: item
                            })
                        })
                        setProducts(_products);
                    })
                    break
                case "Заправка":
                    incomingData.items.map(item=>{
                        _products.push({
                            name: ServerData.getTypeGasById(item.ItemId),
                            itemBusiness: item
                        })
                    })
                    setProducts(_products);
                    break
                case "Маркет 24/7":
                    incomingData.items.map(item=>{
                        const itemType = ServerData.itemsTypes.find(v=>v.IdItem == item.ItemId)
                        _products.push({
                            name: itemType?.Name,
                            itemBusiness: item
                        })
                    })
                    setProducts(_products);
                    break
            }
        })
    },[])
    const [products,setProducts] = useState<ProductType[]>([
        {itemBusiness: {ItemId: 0, Count: 0, Price: 6}, name: 'Ffgfg'}
    ])
    const[currentItem,setCurrentItem] = useState<IncomingItemBusiness>()
    const [isOpenModalOrder,setIsOpenModalOrder] = useState<boolean>(false)
    const [isOpenModalPrice,setIsOpenModalPrice] = useState<boolean>(false)
    return (
        <div style={{width: '100%', height: '100%'}}>
            <Table columns={columns} dataSource={products}/>
            {isOpenModalOrder && <ModalWithInputForm labelInput={"Количество от 150 до 2000"} isOpen labelButton={"Заказать"} onSubmit={()=>{}} onCancel={()=>setIsOpenModalOrder(false)}/>}
            {isOpenModalPrice && <ModalWithInputForm labelInput={"Новая цена"} isOpen labelButton={"Изменить"} onSubmit={()=>{}} onCancel={()=>setIsOpenModalPrice(false)}/>}
        </div>
    );
};

export default Products;