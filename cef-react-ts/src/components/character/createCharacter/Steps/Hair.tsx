import React, {useEffect, useState} from 'react';
import {Config} from "../../../../conf";
import {Button, Card, Segmented, Space, Typography} from "antd";
import {CreateCharacterType, useCreateCharacterContext} from "../context/CreateCharacterContextProvider";


const {Title } = Typography;



const Hair : React.FC = () => {
    const characterContext = useCreateCharacterContext()
    const hairStyleColors: string[] = [
        '#1c1f21', '#272a2c', '#312e2c', '#35261c',
        '#4b321f', '#5c3b24', '#6d4c35', '#6b503b',
        '#765c45', '#7f684e', '#99815d', '#a79369',
        '#af9c70', '#bba063', '#d6b97b', '#dac38e',
        '#9f7f59', '#845039', '#682b1f', '#61120c',
        '#640f0a', '#7c140f', '#a02e19', '#b64b28',
        '#a2502f', '#aa4e2b', '#626262', '#808080',
        '#aaaaaa', '#c5c5c5', '#463955', '#5a3f6b',
        '#763c76', '#ed74e3', '#eb4b93', '#f299bc',
        '#04959e', '#025f86', '#023974', '#3fa16a',
        '#217c61', '#185c55', '#b6c034', '#70a90b',
        '#439d13', '#dcb857', '#e5b103', '#e69102',
        '#f28831', '#fb8057', '#e28b58', '#d1593c',
        '#ce3120', '#ad0903', '#880302', '#1f1814',
        '#291f19', '#2e221b', '#37291e', '#2e2218',
        '#231b15', '#020202', '#706c66', '#9d7a50',
    ]
    const [current,setCurrent] = useState<string | number>('Прическа')

    const[hairsMan,setHairsMan] = useState<Array<number>>([])
    const[hairsWomen,setHairsWomen] = useState<Array<number>>([])

    useEffect(()=>{
        let newHairsMan: any[] = [];
        let newHairsWomen: any[] = [];
        for(let i: number = 1; i <= 36; i++){
            if(i===23)continue;
            newHairsMan = [...newHairsMan,i];
        }
        for(let i: number = 1; i <= 38; i++){
            if(i===24)continue;
            newHairsWomen = [...newHairsWomen,i];
        }
        setHairsMan(newHairsMan);
        setHairsWomen(newHairsWomen);
    },[])



    return (
        <Space align={"start"} direction={"horizontal"} style={{justifyContent: 'space-between', width: Config.screenResolution.width}}>
            <Space>
                <Card>
                    <Space direction={"vertical"} style={{width: 300, overflowY: 'auto'}} align={"center"}>
                        <Segmented options={characterContext.character.gender === 'мужской' ? ['Прическа', 'Борода', 'Брови'] : ['Прическа', 'Макияж', 'Брови']} onChange={(v)=>setCurrent(v)}/>
                        {current === 'Прическа' &&
                            <Space wrap style={{width: 300, height: 'auto'}}>
                                {characterContext.character.gender === 'мужской' &&
                                    hairsMan.map((hair)=>
                                        <img src={require('../../../../assets/images/hairs/male/' + 'Clothing_M_2_' + hair + '.jpg')}
                                             width={67}
                                             height={70}
                                             alt={hair.toString()}
                                             key={hair}
                                             //style={{border: gen.id === currentSelectedGen1.id ? '1px solid rgba(22, 119, 255,400)' : '1px solid transparent'}}
                                             onClick={()=>{
                                                 const newCharacter: CreateCharacterType = characterContext.character;
                                                 newCharacter.hair[0] = hair;
                                                 characterContext.setCharacter(newCharacter);
                                                 mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                                             }}
                                        />
                                    )
                                }
                                {characterContext.character.gender === 'женский' &&
                                    hairsWomen.map((hair)=>
                                        <img src={require('../../../../assets/images/hairs/female/' + 'Clothing_F_2_' + hair + '.jpg')}
                                             width={67}
                                             height={70}
                                             alt={hair.toString()}
                                             key={hair}
                                             onClick={()=>{
                                                 const newCharacter: CreateCharacterType = characterContext.character;
                                                 newCharacter.hair[0] = hair;
                                                 characterContext.setCharacter(newCharacter);
                                                 mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                                             }}
                                        />
                                    )
                                }
                            </Space>
                        }
                    </Space>
                </Card>
            </Space>
            <Space>
                <Card>
                    <Space direction={"vertical"} align={"center"}>
                        <Title style={{textAlign: 'center'}} level={4}>Выберите цвет</Title>
                        <Space direction={"horizontal"} style={{width: 300}} align={"center"}>
                            <Space wrap style={{margin:10}}>
                                {hairStyleColors.map((color, index)=>
                                    <Button
                                        style={{width: 40, height: 40, backgroundColor: color}}
                                        onClick={()=>{
                                            if(current === 'Прическа'){
                                                const newCharacter: CreateCharacterType = characterContext.character;
                                                newCharacter.hair[1] = index;
                                                characterContext.setCharacter(newCharacter);
                                                mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                                            }
                                        }}
                                    />
                                )}
                            </Space>
                        </Space>
                    </Space>
                </Card>
            </Space>
        </Space>
    );
};

export default Hair;