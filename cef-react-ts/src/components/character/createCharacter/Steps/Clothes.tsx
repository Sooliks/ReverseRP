import React from 'react';
import {Config} from "../../../../conf";
import {Card, Space} from "antd";
import {useCreateCharacterContext} from "../context/CreateCharacterContextProvider";
import Switcher, {DataTypeSwitcher} from "../../../../ui/Switcher";






const Clothes: React.FC = () => {
    const characterContext = useCreateCharacterContext()
    const topMaleList: DataTypeSwitcher[] = [
        {value: 0, placeHolder: "Помятая футболка"},
        {value: 1, placeHolder: "Футболка"},
        {value: 7, placeHolder: "Толстовка"}
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
                            <Switcher text={"Верх"} data={topMaleList} onChange={(v)=>console.log(v)}/>
                        </Space>
                    </Space>
                </Card>
            </Space>
        </Space>
    );
};

export default Clothes;