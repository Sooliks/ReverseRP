import React, {useState} from 'react';
import {Button, Divider, Popover, Row, Space, Typography} from "antd";
import {SettingOutlined} from "@ant-design/icons";
import Settings from "./Settings";

const {Text} = Typography;

const MyAuto: React.FC = () => {

    type AutoType = {
        id: number
        name: string
        status: string
        number: string
    }
    const [autoList,setAutoList] = useState<AutoType[]>([
        {id: 0,name: 'BMW M8dgdgdgdggd', status: 'На парковке', number: '64BDFM6'},
    ])

    const handleClickGps = (id: number) =>{

    }
    const handleClickParking = (id: number) =>{

    }

    return (
        <Space direction={"vertical"} style={{width: 221, height: 362, alignItems: 'center', overflowY: 'auto', overflowX: 'hidden'}}>
            {autoList?.length!==0 ? autoList?.map((auto=>
                    <Space align={"center"} style={{width: 210, height: 35, backgroundColor: 'white', borderRadius: '10px', margin: 5, padding: 5, justifyContent: 'space-between'}}>
                        <Space>
                            <Text style={{width: 70}} ellipsis={true}>{auto.name}</Text>
                            <Divider type="vertical"/>
                            <Text type={"secondary"}>{auto.number}</Text>
                        </Space>
                        <Space>
                            <Popover placement="bottomRight" title={auto.name} content={<Settings onClickGps={()=>handleClickGps(auto.id)} onClickParking={()=>handleClickParking(auto.id)}/>} trigger="click">
                                <Button icon={<SettingOutlined />}/>
                            </Popover>
                        </Space>
                    </Space>
            ))
                :
                <Text style={{color: 'white', textAlign: 'center'}}>У вас нету не одного авто</Text>
            }
        </Space>
    );
};

export default MyAuto;