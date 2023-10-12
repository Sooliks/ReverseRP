import React, {useEffect} from 'react';
import {Client} from "../../requests/Client";



type ProductsProps = {
    idBusiness: number
}
const Products: React.FC<ProductsProps> = ({idBusiness}) => {
    useEffect(()=>{
        try {
            Client.callProcServer<string>("RPC::CEF::SERVER:GetProductsMarket", idBusiness).then(data => {
                data = JSON.parse(data);
                console.log(data[0])
            })
        }catch (e) {
            
        }
    },[])


    return (
        <div style={{width: '100%', height: '100%'}}>

        </div>
    );
};

export default Products;