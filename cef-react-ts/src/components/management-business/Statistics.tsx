import React, {useEffect} from 'react';
import {Button, Statistic} from "antd";
import {Client} from "../../requests/Client";


type StatisticsProps = {
    idBusiness: number
}
const Statistics: React.FC<StatisticsProps> = ({idBusiness}) => {
    useEffect(()=>{
        try {
            Client.callProcServer<string>("RPC::CEF::SERVER:GetStatisticsBusiness", idBusiness).then(data => {
                data = JSON.parse(data);
                console.log(data[0])
            })
        }catch (e) {
            
        }
    },[])


    return (
        <div style={{width: '100%', height: '100%'}}>
            <Statistic title="Поситителей сегодня" value={112893} />
            <Statistic title="Баланс предприятия" value={112893} precision={2} />
            <Button style={{ marginTop: 16 }} type="primary">
                Забрать
            </Button>
        </div>
    );
};

export default Statistics;