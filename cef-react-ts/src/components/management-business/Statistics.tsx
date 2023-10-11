import React from 'react';
import {Statistic} from "antd";


type StatisticsProps = {
    idBusiness: number
}
const Statistics: React.FC<StatisticsProps> = ({idBusiness}) => {
    return (
        <div style={{width: '100%', height: '100%'}}>
            <Statistic title="Поситителей сегодня" value={112893} />
            <Statistic title="Баланс предприятия" value={112893} precision={2} />
        </div>
    );
};

export default Statistics;