import React from 'react';
import {Space} from "antd";



type ReverseListType = {
    title: string
    value: string
}

type ReverseListProps = {
    data?: ReverseListType[] | {title: string, value: string}[]
    width?: number
}
const ReverseList: React.FC<ReverseListProps> = ({data,width}) => {


    return (
        <Space direction={"vertical"} style={{width: width ? width : 300}}>

        </Space>
    );
};

export default ReverseList;