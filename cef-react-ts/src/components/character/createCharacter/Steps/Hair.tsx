import React, {useEffect, useState} from 'react';
import {Config} from "../../../../conf";
import {Button, Card, Segmented, Space, Typography} from "antd";
import {CreateCharacterType, useCreateCharacterContext} from "../context/CreateCharacterContextProvider";
import CustomSlider from "../../../../ui/CustomSlider";
import DefaultColorPalette from "../../../../ui/DefaultColorPalette";


const {Title } = Typography;



const Hair : React.FC = () => {
    const characterContext = useCreateCharacterContext()
    const [current,setCurrent] = useState<string | number>('Прическа')


    const[hairsMan,setHairsMan] = useState<Array<number>>([])
    const[hairsWomen,setHairsWomen] = useState<Array<number>>([])
    const[currentHairMan,setCurrentHairMan] = useState<number | undefined>()
    const[currentHairWomen,setCurrentHairWomen] = useState<number | undefined>()

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

        if(characterContext.character.gender==="мужской") setCurrentHairMan(characterContext.character.hair[0])
        else setCurrentHairWomen(characterContext.character.hair[0])
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
                                             style={{cursor: 'pointer', borderRadius: '6px', border: hair === currentHairMan ? '1px solid rgba(22, 119, 255,400)' : '1px solid transparent'}}
                                             onClick={()=>{
                                                 const newCharacter: CreateCharacterType = characterContext.character;
                                                 newCharacter.hair[0] = hair;
                                                 characterContext.setCharacter(newCharacter);
                                                 setCurrentHairMan(hair);
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
                                             style={{cursor: 'pointer', borderRadius: '6px', border: hair === currentHairWomen ? '1px solid rgba(22, 119, 255,400)' : '1px solid transparent'}}
                                             onClick={()=>{
                                                 const newCharacter: CreateCharacterType = characterContext.character;
                                                 newCharacter.hair[0] = hair;
                                                 characterContext.setCharacter(newCharacter);
                                                 setCurrentHairWomen(hair);
                                                 mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                                             }}
                                        />

                                    )
                                }
                            </Space>
                        }
                        {current === 'Борода' &&
                            <Space style={{width: 300, height: 'auto'}}>
                                <CustomSlider
                                    onChange={(v)=>{
                                        const newCharacter: CreateCharacterType = characterContext.character;
                                        newCharacter.headOverlays[1] = v;
                                        characterContext.setCharacter(newCharacter);
                                        mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                                    }}
                                    min={0}
                                    max={29}
                                    style={{width:260}}
                                    step={1}
                                    text={"Тип бороды"}
                                    formatterWork={true}
                                />
                            </Space>
                        }
                        {current === 'Брови' &&
                            <Space style={{width: 300, height: 'auto'}}>
                                <CustomSlider
                                    onChange={(v)=>{
                                        const newCharacter: CreateCharacterType = characterContext.character;
                                        newCharacter.headOverlays[2] = v;
                                        characterContext.setCharacter(newCharacter);
                                        mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                                    }}
                                    min={0}
                                    max={34}
                                    style={{width:260}}
                                    step={1}
                                    text={"Тип бровей"}
                                    formatterWork={true}
                                />
                            </Space>
                        }
                        {current === 'Макияж' &&
                            <Space style={{width: 300, height: 'auto'}} direction={"vertical"}>
                                <CustomSlider
                                    onChange={(v)=>{
                                        const newCharacter: CreateCharacterType = characterContext.character;
                                        newCharacter.headOverlays[4] = v;
                                        characterContext.setCharacter(newCharacter);
                                        mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                                    }}
                                    min={0}
                                    max={95}
                                    style={{width:260}}
                                    step={1}
                                    text={"Макияж"}
                                    formatterWork={true}
                                />
                                <CustomSlider
                                    onChange={(v)=>{
                                        const newCharacter: CreateCharacterType = characterContext.character;
                                        newCharacter.headOverlays[8] = v;
                                        characterContext.setCharacter(newCharacter);
                                        mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                                    }}
                                    min={0}
                                    max={10}
                                    style={{width:260}}
                                    step={1}
                                    text={"Помада"}
                                    formatterWork={true}
                                />
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
                            <DefaultColorPalette onPickColor={(index)=>{
                                if(current === 'Прическа'){
                                    const newCharacter: CreateCharacterType = characterContext.character;
                                    newCharacter.hair[1] = index;
                                    characterContext.setCharacter(newCharacter);
                                    mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                                }
                                if(current === 'Борода'){
                                    const newCharacter: CreateCharacterType = characterContext.character;
                                    newCharacter.headOverlaysColors[1] = index;
                                    characterContext.setCharacter(newCharacter);
                                    mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                                }
                                if(current === 'Брови'){
                                    const newCharacter: CreateCharacterType = characterContext.character;
                                    newCharacter.headOverlaysColors[2] = index;
                                    characterContext.setCharacter(newCharacter);
                                    mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                                }
                                if(current === 'Макияж'){
                                    const newCharacter: CreateCharacterType = characterContext.character;
                                    newCharacter.headOverlaysColors[8] = index;
                                    characterContext.setCharacter(newCharacter);
                                    mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                                }
                            }}/>
                        </Space>
                    </Space>
                </Card>
            </Space>
        </Space>
    );
};

export default Hair;