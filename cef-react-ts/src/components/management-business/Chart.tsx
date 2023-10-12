import React, {useEffect, useState} from 'react';
import {Line} from "react-chartjs-2";
import {ChartData} from "chart.js";
import "chart.js/auto";
import {StatisticType} from "./Statistics";
import {Client} from "../../requests/Client";






type ChartProps = {
    idBusiness: number
}

const Chart: React.FC<ChartProps> = ({idBusiness}) => {
    useEffect(()=>{
        try {
            Client.callProcServer<string>("RPC::CEF::SERVER:GetStatisticsBusiness", idBusiness).then(d => {
                const statistics: StatisticType[] = JSON.parse(d);
                const labels: string[] = [];
                statistics.map(stat=>labels.push(stat.DateTime))
                const data: number[] = [];
                statistics.map(stat=>data.push(stat.CountVisitors))
                setLineChartData({
                    labels: labels,
                    datasets: [
                        {
                            label: 'Кол-во посетителей',
                            data: data,
                        },
                    ]
                })
            })
        }catch (e) {

        }
    },[])

    const [lineChartData, setLineChartData] = useState<ChartData<"line">>({
        labels: [''],
        datasets: [
            {
                label: 'Кол-во посетителей',
                data: [1,4],
            },
        ]
    });


    return (
        <Line
            data={lineChartData}
            datasetIdKey='id'
        />
    );
};

export default Chart;