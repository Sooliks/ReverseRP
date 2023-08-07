import React, {useState} from 'react';
import {Config} from "../../../../conf";
import {Card, Segmented, Space} from "antd";
import {useCreateCharacterContext} from "../context/CreateCharacterContextProvider";





const Clothes: React.FC = () => {
    const characterContext = useCreateCharacterContext()
    const [current,setCurrent] = useState<string | number>('Верх')

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
                        <Segmented value={current} options={['Очки','Верх', 'Низ', 'Обувь']} onChange={(v)=>setCurrent(v)}/>
                    </Space>
                </Card>
            </Space>
        </Space>
    );
};

export default Clothes;