import React, {useEffect, useState} from 'react';
import {Card, Segmented, Space} from "antd";
import {Config} from "../../../../conf";




type Gen = {
    id: number,
    pathToFace: string
}


const Genetics: React.FC = () => {
    const [currentGen,setCurrentGen] = useState<string | number>('Ген 1');
    const [gens1List,setGens1List] = useState<Gen[]>([]);
    const [gens2List,setGens2List] = useState<Gen[]>([]);

    const [currentSelectedGen1,setCurrentSelectedGen1] = useState<Gen>()
    const [currentSelectedGen2,setCurrentSelectedGen2] = useState<Gen>()

    useEffect(()=>{
        let gens1: Gen[] = [];
        let gens2: Gen[] = [];
        for(let i: number = 1; i <= 24; i++){
            gens1 = [...gens1,{id: i, pathToFace: `${i}.png`}];
        }
        for(let i: number = 1; i <= 22; i++){
            gens2 = [...gens2,{id: i, pathToFace: `${i}.png`}];
        }
        setGens1List(gens1);
        setGens2List(gens2);
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
                                    <img src={require('../../../../assets/images/faces/male/' + gen.pathToFace)} width={69} height={70} alt={gen.id.toString()} key={gen.id}></img>
                                )}
                            </Space>
                        }
                        {currentGen === 'Ген 2' &&
                            <Space wrap style={{width: 300, height: 'auto'}}>
                                {gens2List.map(gen=>
                                    <img src={require('../../../../assets/images/faces/female/' + gen.pathToFace)}  width={69} height={70} alt={gen.id.toString()}></img>
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