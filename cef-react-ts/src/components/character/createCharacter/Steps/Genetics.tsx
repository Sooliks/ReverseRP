import React, {useEffect, useState} from 'react';
import {Card, Segmented, Space} from "antd";
import {Config} from "../../../../conf";



type GenList = {
    id: number,
    pathToFace: string
}


const Genetics: React.FC = () => {
    const [currentGen,setCurrentGen] = useState<string | number>('Ген 1');
    const [gens1List,setGens1List] = useState<GenList[]>([]);
    const [gens2List,setGens2List] = useState<GenList[]>([]);

    useEffect(()=>{
        let gens1: GenList[] = [];
        let gens2: GenList[] = [];
        for(let i: number = 1; i <= 24; i++){
            gens1 = [...gens1,{id: i, pathToFace: `../../../../assets/images/faces/male/${i}.png`}];
        }
        for(let i: number = 1; i <= 22; i++){
            gens2 = [...gens2,{id: i, pathToFace: `../../../../assets/images/faces/female/${i}.png`}];
        }
        setGens1List(gens1);
        setGens2List(gens2);
    },[])

    return (
        <Space align={"start"} direction={"horizontal"} style={{justifyContent: 'space-between', width: Config.screenResolution.width}}>
            <Space>
                <Card>
                    <Space style={{width: 320, flexDirection: 'column', alignItems: 'center'}}>
                        <Segmented options={['Ген 1', 'Ген 2']} onChange={(v)=>setCurrentGen(v)}/>
                        {currentGen === 'Ген 1' &&
                            <Space wrap style={{width: 330, height: 'auto'}}>
                                {gens1List.map(gen=>
                                    <img src={gen.pathToFace} alt={gen.id.toString()} key={gen.id} style={{width: 30, height: 30}}></img>
                                )}
                            </Space>
                        }
                        {currentGen === 'Ген 2' &&
                            <Space wrap style={{width: 330, height: 'auto'}}>
                                {gens2List.map(gen=>
                                    <img src={gen.pathToFace} alt={gen.id.toString()} key={gen.id} style={{width: 30, height: 30}}></img>
                                )}
                            </Space>
                        }
                    </Space>
                </Card>
            </Space>
            <Space>
                <Card style={{width: 350}}>

                </Card>
            </Space>
        </Space>
    );
};

export default Genetics;