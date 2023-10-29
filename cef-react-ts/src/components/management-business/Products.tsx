import React, {useEffect, useState} from 'react';
import {Client} from "../../requests/Client";



type ProductsProps = {
    idBusiness: number
}

type IncomingProductType = {

}

type ProductType = {
    name: string
    count: number
    price: number
}

const Products: React.FC<ProductsProps> = ({idBusiness}) => {
    useEffect(()=>{
        Client.callProcServer<string>("RPC::CEF::SERVER:GetProductsMarket", idBusiness).then(data => {
            console.log(data)
            data = JSON.parse(data);

        })
    },[])
    const [products,setProducts] = useState<ProductType[]>([])

    return (
        <div style={{width: '100%', height: '100%'}}>

        </div>
    );
};

export default Products;