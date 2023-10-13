import React, {useEffect, useState} from 'react';
import {Client} from "../../requests/Client";



type ProductsProps = {
    idBusiness: number
}

type IncomingProductType = {

}

type ProductType = {

}

const Products: React.FC<ProductsProps> = ({idBusiness}) => {
    useEffect(()=>{
        try {
            Client.callProcServer<string>("RPC::CEF::SERVER:GetProductsMarket", idBusiness).then(data => {
                data = JSON.parse(data);

            })
        }catch (e) {
            
        }
    },[])
    const [products,setProducts] = useState<ProductType[]>([])

    return (
        <div style={{width: '100%', height: '100%'}}>

        </div>
    );
};

export default Products;