import React, {useState} from 'react';
import {Card, Divider, Space, Typography} from "antd";

const {Text} = Typography;

type ReverseListType = {
    name: string
    value: string
}

type ReverseListProps = {
    data: ReverseListType[] | {name: string, value: string}[]
    width?: number
    onClick: (name: string, value: string) => void
}
const ReverseList: React.FC<ReverseListProps> = ({data,width, onClick}) => {


    return (
        <Card style={{height: 900, overflowY: 'auto'}}>
            <Space direction={"vertical"}>
                {data.map((item)=>
                    <Space
                        onClick={()=>onClick(item.name, item.value)}
                        onMouseOver={(e)=>e.currentTarget.style.backgroundColor = "rgba(5, 5, 5, 0.06)"}
                        onMouseOut={(e)=>e.currentTarget.style.backgroundColor = "white"}
                        style={{width: width ? width : 300, marginTop: 12, borderBottom: '1px solid gray',paddingBottom: 10, paddingTop: 10}}>
                        <Text style={{marginLeft: 5}}>{item.name}</Text>
                    </Space>
                )}
            </Space>
        </Card>
    );
};

export default ReverseList;