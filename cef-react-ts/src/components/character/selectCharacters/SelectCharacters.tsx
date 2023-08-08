import React, {useEffect, useState} from 'react';
import {Config} from "../../../conf";
import {Button, Card, Space, Tooltip, Typography} from "antd";
import {PlusOutlined} from "@ant-design/icons";
import {Client} from "../../../requests/Client";

const { Text, Title } = Typography;

type CharacterType = {
    Id: number
    FirstName: string
    LastName: string
    Lvl: number
    Money: number
    MoneyBank: number
}


const SelectCharacters : React.FC = () => {
    //const navigate = useNavigate();
    //{id: 0, firstName: '1', lastName: 'r', lvl: 23, money: 3535, moneyBank: 633}
    const [characters,setCharacters] = useState<CharacterType[]>([])

    try {
        mp.events.add("SERVER::CEF::ADD_CHARACTERS_LIST",(json)=>{
            json = JSON.parse(json);
            if(json[0].length===0)return

            setCharacters(json[0])
        })
    }catch (e) {}
    const count = [0,1,2];
    useEffect(()=>{

    },[])


    return (
        <Space align={"center"} direction={"vertical"} style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <Space>
                <Card title={"Персонажи"}>
                    <Space style={{minWidth: 1300, minHeight: 700, justifyContent: 'space-around'}}>
                        {count.map((value)=>
                            <Card>
                                {characters[value] !== undefined && characters.length!==0 ?
                                    <Space direction={"vertical"} style={{width: 380, height: 600, justifyContent: 'space-between'}}>
                                        <Space direction={"vertical"}>
                                            <Title level={4}>Информация о персонаже</Title>
                                            <Space>
                                                <Text type={"secondary"}>Имя: </Text>
                                                <Text>{characters[value].FirstName}</Text>
                                            </Space>
                                            <Space>
                                                <Text type={"secondary"}>Фамилия: </Text>
                                                <Text>{characters[value].LastName}</Text>
                                            </Space>
                                            <Space>
                                                <Text type={"secondary"}>Денег в банке: </Text>
                                                <Text>{characters[value].MoneyBank+'$'}</Text>
                                            </Space>
                                            <Space>
                                                <Text type={"secondary"}>Денег наличных: </Text>
                                                <Text>{characters[value].Money+'$'}</Text>
                                            </Space>
                                            <Space>
                                                <Text type={"secondary"}>Уровень: </Text>
                                                <Text>{characters[value].Lvl}</Text>
                                            </Space>
                                        </Space>
                                        <Button style={{width: '100%'}} onClick={()=>{
                                            Client.triggerServer("CEF::SERVER::ON_SELECT_CHARACTER",characters[value].Id)
                                        }}>
                                            Войти
                                        </Button>
                                    </Space>
                                    :
                                    <Space style={{width: 380, height: 600, justifyContent: 'center'}}>
                                        <Tooltip title={"Создать"}>
                                            <Button size={"large"} icon={<PlusOutlined />} style={{alignSelf: 'center'}} onClick={()=>{
                                                Client.triggerServer("CEF::SERVER::ON_CLICK_CREATE_CHARACTER");
                                            }}/>
                                        </Tooltip>
                                    </Space>
                                }
                            </Card>
                        )}
                    </Space>
                </Card>
            </Space>
        </Space>
    );
};

export default SelectCharacters;