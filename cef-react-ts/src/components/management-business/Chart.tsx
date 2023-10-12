import React, {useEffect, useState} from 'react';
import {Line} from "react-chartjs-2";
import {ChartData} from "chart.js";
import "chart.js/auto";
import {StatisticType} from "./Statistics";



type ChartProps = {
    statistics: StatisticType[]
}

const Chart: React.FC<ChartProps> = ({statistics}) => {
    useEffect(()=>{
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