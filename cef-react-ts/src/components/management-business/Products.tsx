import React, {useEffect, useState} from 'react';
import {Client} from "../../requests/Client";
import {ServerData} from "../../data/ServerData";



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

const Products: React.FC<ProductsProps> = ({idBusiness}) => {
    useEffect(()=>{
        Client.callProcServer<string>("RPC::CEF::SERVER:GetProductsBusiness", idBusiness).then(data => {
            console.log(data)
            const incomingData: IncomingData = JSON.parse(data);
            switch (incomingData.businessType) {
                case "Автосалон высокого класса":
                    Client.callProcServer<string>("RPC::CEF::SERVER:GetVehiclesTypes").then(data=>{
                        ServerData.vehiclesTypes = JSON.parse(data);
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

        </div>
    );
};

export default Products;