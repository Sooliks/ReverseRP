import React, {useState} from 'react';
import {Config} from "../../../conf";
import {Button, Card, Descriptions, DescriptionsProps, Space, Tooltip} from "antd";
import {PlusOutlined} from "@ant-design/icons";
import {useNavigate} from "react-router-dom";

const SelectCharacters : React.FC = () => {
    const navigate = useNavigate();

    const [items,setItems] = useState<DescriptionsProps['items'][]>([
        [
            {
                label: 'Имя',
                children: 'Zhou',
            },
            {
                label: 'Фамилия',
                children: 'Babrov',
            },
            {
                label: 'Уровень',
                children: '8',
            },
            {
                label: 'Денег в банке',
                children: '1000$',
            },
            {
                label: 'Наличные',
                children: '10000$',
            },
        ],
        [

        ],
        [

        ]
    ])


    return (
        <Space align={"center"} direction={"vertical"} style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <Space>
                <Card title={"Персонажи"}>
                    <Space style={{width: 1300, height: 700, justifyContent: 'space-around'}}>
                        {items.map((character,index)=>
                            <Card key={index}>
                                <Space align={character?.length === 0 ? 'center' : undefined} direction={"vertical"} style={{justifyContent: character?.length === 0 ? 'center' : 'space-between',height: 500, width: 380}}>
                                    {character?.length !== 0 && <Descriptions column={1} title="Информация о персонаже" items={items[index]} />}
                                    {character?.length === 0 ?
                                        <Tooltip title={"Создать"}>
                                            <Button size={"large"} icon={<PlusOutlined />} style={{alignSelf: 'center'}} onClick={()=>{
                                                navigate('/createcharacter')
                                            }}/>
                                        </Tooltip>
                                        :
                                        <Button style={{width: '100%'}} onClick={()=>{

                                        }}>
                                            Войти
                                        </Button>
                                    }
                                </Space>
                            </Card>
                        )}
                    </Space>
                </Card>
            </Space>
        </Space>
    );
};

export default SelectCharacters;