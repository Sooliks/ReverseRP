import React, {useState} from 'react';
import {Config} from "../../conf";
import {Space, Typography} from "antd";
import img from '../../assets/images/phone.png'
import ListApps from "./ListApps";
import MyAuto from "./apps/MyAuto/MyAuto";
import MyHome from "./apps/MyHome/MyHome";

const {Text} = Typography;

const Phone: React.FC = () => {

    const [currentApp,setCurrentApp] = useState<string>()

    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', justifyContent: 'end', alignItems: 'end'}}>
            <div style={{background: `url(${img}) no-repeat center/cover`, width: 300, height: 500, display: 'flex', justifyContent: 'center'}}>
                <div style={{border: '2px solid black', width: 221, height: 362, marginTop: 64, marginRight: 2, backgroundColor: 'black'}}>
                    <div style={{width: '100%', height: 14, borderBottom: '1px solid white', display: 'flex', justifyContent: 'space-between', backgroundColor: 'gray'}}>
                        <Text style={{color: 'white', fontSize: '10px', marginLeft: 2}}>3:52</Text>
                        <Text style={{color: 'white', fontSize: '10px'}}>100%</Text>
                    </div>
                    {currentApp === undefined && <ListApps onClickApp={(v)=>setCurrentApp(v)}/>}
                    {currentApp === 'MyAuto' && <MyAuto/>}
                    {currentApp === 'MyHome' && <MyHome/>}
                </div>
                <div
                    style={{borderRadius: '50%', width: 44, height: 44, backgroundColor: 'white', position: 'absolute', marginTop: 435, border: '1px solid black'}}
                    onClick={()=>setCurrentApp(undefined)}
                />
            </div>
        </Space>
    );
};

export default Phone;