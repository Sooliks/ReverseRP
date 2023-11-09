import React, {useEffect, useState} from 'react';
import {Button, Divider, Space, Statistic} from "antd";
import {Client} from "../../requests/Client";
import Chart from "./Chart";


type StatisticsProps = {
    idBusiness: number
}
export type StatisticType = {
    DateTime: string
    CountVisitors: number
    PurchasedGoods: number
}
type ExtendStatisticType = {
    CountVisitorsCurrentDay: number
    Bank: number
    CountVisitorsMonth: number
}
const Statistics: React.FC<StatisticsProps> = ({idBusiness}) => {
    useEffect(()=>{
        Client.callProcServer<string>("RPC::CEF::SERVER:GetExtendedStatistic", idBusiness).then(data => {
            setStatistic(JSON.parse(data));
        })
    },[])
    const [statistic,setStatistic] = useState<ExtendStatisticType>({
        CountVisitorsCurrentDay: 0,
        CountVisitorsMonth: 0,
        Bank: 0
    })
    const handleClickGetBank = () => {
        Client.triggerServer("CEF::SERVER:ON_GET_BANK", idBusiness)
        setStatistic({...statistic, Bank: 0});
    }
    return (
        <div style={{width: '100%', height: '100%'}}>
            <Space align={"start"} style={{marginTop: '4vh'}}>
                <Statistic title="Посетителей сегодня" value={statistic.CountVisitorsCurrentDay} />
                <Divider type={"vertical"} style={{height: 130}}/>
                <Space direction={"vertical"}>
                    <Statistic title="Баланс предприятия" value={statistic.Bank} precision={2} />
                    <Button style={{ marginTop: 16 }} type="primary" onClick={handleClickGetBank}>
                        Забрать
                    </Button>
                </Space>
                <Divider type={"vertical"} style={{height: 130}}/>
                <Statistic title="Посетителей за этот месяц" value={statistic.CountVisitorsMonth} />
            </Space>
            <Divider/>
            <Chart idBusiness={idBusiness}/>
        </div>
    );
};

export default Statistics;