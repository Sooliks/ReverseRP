import React, {useState} from 'react';
import {Space, Typography} from "antd";
import {MenuOutlined, PhoneOutlined, PlusOutlined, UserOutlined} from "@ant-design/icons";
const { Title } = Typography;

const Keys : React.FC = () => {
    const [keys,setKeys] = useState([
        {text:"Телефон", key:"P", icon: <PhoneOutlined style={{fontSize: '34px', color: '#9a9a9d'}}/>},
        {text:"Меню", key:"M", icon: <MenuOutlined style={{fontSize: '34px', color: '#9a9a9d'}}/>},
        {text:"Курсор", key:"F2", icon: <PlusOutlined style={{fontSize: '34px', color: '#9a9a9d'}}/>},
        {text:"Инвентарь", key:"I", icon: <UserOutlined style={{fontSize: '34px', color: '#9a9a9d'}}/>},
    ])
    try {
        mp.events.add("CLIENT::CEF::HUD_IS_VISIBLE_KEYS_FOR_CARS", (visible: boolean) => {

        })
    }catch (e){

    }

    return (
        <Space direction={"vertical"}>
            {keys.map(key=>
                <Space direction={"horizontal"} align={"center"}>
                    <Space align={"center"} key={key.text} style={{width:40,height:42, textAlign: 'center', padding: 0, backgroundColor: 'white', borderRadius:'10px', justifyContent: 'center'}}>
                        <Title level={4} style={{textAlign:"center", margin: 0, color:'#4b4a4a'}}>{key.key}</Title>
                    </Space>
                    {key.icon}
                </Space>
            )}
        </Space>
    );
};

export default Keys;