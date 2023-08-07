import React from 'react';
import {Card, Space} from "antd";
import {Config} from "../../../../conf";
import CustomSlider from "../../../../ui/CustomSlider";
import {useCreateCharacterContext} from "../context/CreateCharacterContextProvider";

type FacePropertiesType = {
    id: number,
    text: string,
}


const Face: React.FC = () => {
    const characterContext = useCreateCharacterContext()
    const faceProperties: FacePropertiesType[] = [
        {id: 0, text: 'Ширина носа'},
        {id: 1, text: 'Высота носа'},
        {id: 2, text: 'Длина кончика носа'},
        {id: 3, text: 'Глубина моста носа'},
        {id: 4, text: 'Высота кончика носа'},
        {id: 5, text: 'Поломанность носа'},
        {id: 6, text: 'Высота бровей'},
        {id: 7, text: 'Глубина бровей'},
        {id: 8, text: 'Высота скул'},
        {id: 9, text: 'Ширина скул"'},
        {id: 10, text: 'Глубина щеки'},
        {id: 11, text: 'Размер глаз'},
        {id: 12, text: 'Толщина губ'},
        {id: 13, text: 'Ширина челюсти'},
        {id: 14, text: 'Форма челюсти'},
        {id: 15, text: 'Высота подбородка'},
        {id: 16, text: 'Глубина подбородка'},
        {id: 17, text: 'Ширина подбородка'},
        {id: 18, text: 'Отступ подбородка'},
        {id: 19, text: 'Шея'},
    ]


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
                        {faceProperties.map(face=>
                            <CustomSlider
                                text={face.text}
                                onChange={(value)=>{
                                    const newCharacter = characterContext.character;
                                    newCharacter.faceFeatures[face.id] = value;
                                    characterContext.setCharacter(newCharacter);
                                    mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(newCharacter))
                                }}
                                min={-1}
                                max={1}
                                defaultValue={characterContext.character.faceFeatures[face.id]}
                                style={{width:260}}
                                step={0.1}
                            />
                        )}
                    </Space>
                </Card>
            </Space>
        </Space>
    );
};

export default Face;