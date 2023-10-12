import React, {useEffect, useState} from 'react';
import {Button, Divider, Space, Statistic} from "antd";
import {Client} from "../../requests/Client";
import Chart from "./Chart";


type StatisticsProps = {
    idBusiness: number
}

export type StatisticType = {
    DateTime: string,
    CountVisitors: number
}

const Statistics: React.FC<StatisticsProps> = ({idBusiness}) => {
    useEffect(()=>{

    },[])



    return (
        <div style={{width: '100%', height: '100%'}}>
            <Space align={"start"} style={{marginTop: '4vh'}}>
                <Statistic title="Поситителей сегодня" value={112893} />
                <Divider type={"vertical"} style={{height: 130}}/>
                <Space direction={"vertical"}>
                    <Statistic title="Баланс предприятия" value={112893} precision={2} />
                    <Button style={{ marginTop: 16 }} type="primary">
                        Забрать
                    </Button>
                </Space>
            </Space>
            <Divider/>
            <Chart idBusiness={idBusiness}/>
        </div>
    );
};

export default Statistics;