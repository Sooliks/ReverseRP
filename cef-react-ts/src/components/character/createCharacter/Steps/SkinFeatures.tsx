import React, {useEffect, useState} from 'react';
import {Card, Space} from "antd";
import {Config} from "../../../../conf";
import CustomSlider from "../../../../ui/CustomSlider";
import {useCreateCharacterContext} from "../context/CreateCharacterContextProvider";
import {Client} from "../../../../requests/Client";
import {TypeCameraOnPlayer} from "../../../../enums/typeCameraOnPlayerEnum";

type SkinPropertiesType = {
    id: number,
    text: string,
    max: number
}

const SkinFeatures: React.FC = () => {
    const characterContext = useCreateCharacterContext()
    const skinProperties: SkinPropertiesType[] = [
        {id: 0, text: 'Недостатки кожи', max: 24},
        {id: 3, text: 'Старение', max: 15},
        {id: 5, text: 'Покраснение', max: 33},
        {id: 7, text: 'Солнечные ожоги', max: 11},
        {id: 9, text: 'Родинки/Веснушки', max: 18},
        {id: 10, text: 'Волосы на груди', max: 17},
        {id: 11, text: 'Пятна на теле', max: 12},
    ]
    const formatter = (value: number) => {
        if(value === currentChanged.max){
            return 'Нету'
        }
        else{
            return value
        }
    };
    const[currentChanged, setCurrentChanged] = useState<SkinPropertiesType>(skinProperties[0])
    useEffect(()=>{
        Client.setCameraOnPlayer(TypeCameraOnPlayer.Body)
    },[])

    return (
        <Space align={"start"} direction={"horizontal"} style={{justifyContent: 'space-between', width: Config.screenResolution.width}}>
            <Space>
                <Card>
                    <Space
                        direction={"vertical"}
                        style={{
                            width: 300,
                            height: 600,
                            overflowY: 'auto'
                        }}
                    >
                        {skinProperties.map(skin=>
                            <CustomSlider
                                text={skin.text}
                                onChange={(value)=>{
                                    const newCharacter = characterContext.character;
                                    newCharacter.headOverlays[skin.id] = value;
                                    characterContext.setCharacter(newCharacter);
                                    setCurrentChanged(skin)
                                    mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(newCharacter))
                                }}
                                min={0}
                                max={skin.max}
                                defaultValue={characterContext.character.headOverlays[skin.id]}
                                style={{width:260}}
                                step={1}
                                formatterWork={true}
                            />
                        )}
                    </Space>
                </Card>
            </Space>
        </Space>
    );
};

export default SkinFeatures;