import React from 'react';
import {Config} from "../../../../conf";
import {Card, Space} from "antd";
import {CreateCharacterType, useCreateCharacterContext} from "../context/CreateCharacterContextProvider";
import Switcher, {DataTypeSwitcher} from "../../../../ui/Switcher";






const Clothes: React.FC = () => {
    const characterContext = useCreateCharacterContext()
    const topMaleList: DataTypeSwitcher[] = [
        {value: 0, placeHolder: "Помятая футболка"},
        {value: 1, placeHolder: "Футболка"},
        {value: 7, placeHolder: "Толстовка"}
    ]
    const legsMaleList: DataTypeSwitcher[] = [
        {value: 1, placeHolder: "Джинсы"},
        {value: 5, placeHolder: "Спортивки"},
        {value: 12, placeHolder: "Шорты"}
    ]
    const shoesMaleList: DataTypeSwitcher[] = [
        {value: 5, placeHolder: "Шлепки"},
        {value: 1, placeHolder: "Кроссовки"},
        {value: 6, placeHolder: "Тапки"}
    ]

    const topFemaleList: DataTypeSwitcher[] = [
        {value: 0, placeHolder: "Помятая футболка"},
        {value: 1, placeHolder: "Джинсовка"},
        {value: 7, placeHolder: "Пиджак"}
    ]
    const legsFemaleList: DataTypeSwitcher[] = [
        {value: 1, placeHolder: "Джинсы"},
        {value: 2, placeHolder: "Спортивки"},
        {value: 8, placeHolder: "Юбка"}
    ]
    const shoesFemaleList: DataTypeSwitcher[] = [
        {value: 5, placeHolder: "Шлепки"},
        {value: 1, placeHolder: "Кроссовки"},
        {value: 6, placeHolder: "Каблуки"}
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
                        align={"center"}
                    >
                        <Space direction={"vertical"} style={{width: 300, height: 'auto'}}>
                            <Switcher text={"Верх"} data={characterContext.character.gender === "мужской" ? topMaleList : topFemaleList} onChange={(value) => {
                                const newCharacter: CreateCharacterType = characterContext.character;
                                newCharacter.clothing[0] = value;
                                characterContext.setCharacter(newCharacter);
                                mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                            }}/>
                            <Switcher text={"Низ"} data={characterContext.character.gender === "мужской" ? legsMaleList : legsFemaleList} onChange={(value)=>{
                                const newCharacter: CreateCharacterType = characterContext.character;
                                newCharacter.clothing[1] = value;
                                characterContext.setCharacter(newCharacter);
                                mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                            }}/>
                            <Switcher text={"Обувь"} data={characterContext.character.gender === "мужской" ? shoesMaleList : shoesFemaleList} onChange={(value)=>{
                                const newCharacter: CreateCharacterType = characterContext.character;
                                newCharacter.clothing[2] = value;
                                characterContext.setCharacter(newCharacter);
                                mp.trigger("CEF::CLIENT::ON_CHANGE_CHARACTER",JSON.stringify(characterContext.character))
                            }}/>
                        </Space>
                    </Space>
                </Card>
            </Space>
        </Space>
    );
};

export default Clothes;