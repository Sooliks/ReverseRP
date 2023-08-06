import React, {ReactEventHandler, useEffect, useState} from 'react';
import {Card, Segmented, Slider, Space, Typography} from "antd";
import {Config} from "../../../../conf";
import {CreateCharacterType, useCreateCharacterContext} from "../context/CreateCharacterContextProvider";

const {Text} = Typography;


type GenType = {
    id: number,
    pathToFace: string,
    active: boolean
}


const Genetics: React.FC = () => {
    const characterContext = useCreateCharacterContext()

    const [currentGen,setCurrentGen] = useState<string | number>('Ген 1');
    const [gens1List,setGens1List] = useState<GenType[]>([]);
    const [gens2List,setGens2List] = useState<GenType[]>([]);

    const [currentSelectedGen1,setCurrentSelectedGen1] = useState<GenType>({id: 1, active: false, pathToFace: '1.png'})
    const [currentSelectedGen2,setCurrentSelectedGen2] = useState<GenType>({id: 1, active: false, pathToFace: '1.png'})

    useEffect(()=>{
        let gens1: GenType[] = [];
        let gens2: GenType[] = [];
        for(let i: number = 1; i <= 24; i++){
            gens1 = [...gens1,{id: i, pathToFace: `${i}.png`, active: false}];
        }
        for(let i: number = 1; i <= 22; i++){
            gens2 = [...gens2,{id: i, pathToFace: `${i}.png`, active: false}];
        }
        setGens1List(gens1);
        setGens2List(gens2);
    },[])

    const handleChangeFirstGen = (gen: GenType) => {
        setCurrentSelectedGen1(gen);
        const newCharacter: CreateCharacterType = characterContext.character;
        newCharacter.blendData[0] = gen.id;
        characterContext.setCharacter(newCharacter);
    }
    const handleChangeSecondGen = (gen: GenType) => {
        setCurrentSelectedGen2(gen);
        const newCharacter: CreateCharacterType = characterContext.character;
        newCharacter.blendData[1] = gen.id;
        characterContext.setCharacter(newCharacter);
    }
    useEffect(()=>{
        console.log(characterContext.character)
        setCurrentSelectedGen1({id: characterContext.character.blendData[0], active: true,
            pathToFace: `${characterContext.character.blendData[0]}.png`
        })
        setCurrentSelectedGen2({id: characterContext.character.blendData[1], active: true,
            pathToFace: `${characterContext.character.blendData[1]}.png`
        })
    },[])

    return (
        <Space align={"start"} direction={"horizontal"} style={{justifyContent: 'space-between', width: Config.screenResolution.width}}>
            <Space>
                <Card>
                    <Space direction={"vertical"} align={"center"}>
                        <Segmented options={['Ген 1', 'Ген 2']} onChange={(v)=>setCurrentGen(v)}/>
                        {currentGen === 'Ген 1' &&
                            <Space wrap style={{width: 300, height: 'auto'}}>
                                {gens1List.map(gen=>
                                    <img src={require('../../../../assets/images/faces/male/' + gen.pathToFace)}
                                         width={67}
                                         height={70}
                                         alt={gen.id.toString()}
                                         key={gen.id}
                                         style={{border: gen.id === currentSelectedGen1.id ? '1px solid rgba(22, 119, 255,400)' : '1px solid transparent'}}
                                         onClick={()=>handleChangeFirstGen(gen)}
                                    />
                                )}
                            </Space>
                        }
                        {currentGen === 'Ген 2' &&
                            <Space wrap style={{width: 300, height: 'auto'}}>
                                {gens2List.map(gen=>
                                    <img src={require('../../../../assets/images/faces/female/' + gen.pathToFace)}
                                         width={67}
                                         height={70}
                                         alt={gen.id.toString()}
                                         key={gen.id}
                                         style={{border: gen.id === currentSelectedGen2.id ? '1px solid rgba(22, 119, 255,400)' : '1px solid transparent'}}
                                         onClick={()=>handleChangeSecondGen(gen)}
                                    />
                                )}
                            </Space>
                        }
                    </Space>
                </Card>
            </Space>
            <Space>
                <Card>
                    <Space direction={"vertical"} style={{width: 300}}>
                        <Space direction={"horizontal"} style={{justifyContent: 'center', width: 300}}>
                            <img
                                width={100}
                                height={100}
                                src={require('../../../../assets/images/faces/male/' + currentSelectedGen1.pathToFace)}
                                alt={currentSelectedGen1.id.toString()}
                            />
                            <img
                                width={100}
                                height={100}
                                src={require('../../../../assets/images/faces/female/' + currentSelectedGen2.pathToFace)}
                                alt={currentSelectedGen2.id.toString()}
                            />
                        </Space>
                        <Space direction={"vertical"} style={{justifyContent: 'center', width: 300}}>
                            <Text style={{textAlign: 'center'}}>Схожесть</Text>
                            <Slider
                                defaultValue={characterContext.character.blendData[2]}
                                max={1}
                                min={0}
                                step={0.1}
                                tooltipVisible={false}
                                onChange={(value: number)=>{
                                    const newCharacter: CreateCharacterType = characterContext.character;
                                    newCharacter.blendData[2] = value;
                                    characterContext.setCharacter(newCharacter);
                                }}
                            />
                            <Text>Цвет кожи</Text>
                            <Slider
                                defaultValue={characterContext.character.blendData[3]}
                                max={1}
                                min={0}
                                step={0.1}
                                tooltipVisible={false}
                                onChange={(value: number)=>{
                                    const newCharacter: CreateCharacterType = characterContext.character;
                                    newCharacter.blendData[3] = value;
                                    characterContext.setCharacter(newCharacter);
                                }}
                            />
                        </Space>
                    </Space>
                </Card>
            </Space>
        </Space>
    );
};

export default Genetics;