import React, {useState} from 'react';
import {Config} from "../../conf";
import {Button, Card, Divider, Space} from "antd";
import {Client} from "../../requests/Client";
import {CloseOutlined} from "@ant-design/icons";

import classes from './AdminPanel.module.css'

enum AdminLevels
{
    Helper = 1,
    SeniorHelper = 2,
    JuniorModerator = 3,
    MiddleModerator = 4,
    SeniorModerator = 5,
    JuniorAdmin = 6,
    MiddleAdmin = 7,
    SeniorAdmin = 8
}

type AdminPropertiesType = {
    invisibility: boolean
    godMode: boolean
}


const AdminPanel: React.FC = () => {

    //TODO дефолт админ лвл поставить 0
    const[adminLvl, setAdminLvl] = useState<number>(8);
    const [adminCharacterProperties, setAdminCharacterProperties] = useState<AdminPropertiesType>({
        invisibility: false,
        godMode: false
    })

    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', justifyContent: 'center'}}>
            <Card title={"Админ панель"} extra={<Button icon={<CloseOutlined/>} onClick={()=>Client.closeWindow()}/>}>
                <div style={{width: '35vw', height: '70vh'}}>
                    <div style={{display: 'flex', flexDirection: 'row', justifyContent: 'space-around'}}>
                        <Button className={classes.buttonHeader}>Репорты</Button>
                        <Button className={classes.buttonHeader}>Логи</Button>
                        <Button className={classes.buttonHeader}>Игроки</Button>
                        <Button className={classes.buttonHeader}>Админы</Button>
                    </div>
                    <Divider type={"horizontal"}/>
                    {adminLvl >= AdminLevels.Helper && <Button className={classes.button}>Следить за игроком</Button>}
                    {adminLvl >= AdminLevels.JuniorAdmin && adminCharacterProperties.invisibility ?
                        <Button className={classes.button} onClick={()=>setAdminCharacterProperties({...adminCharacterProperties, invisibility: false})}>Выключить невидимость</Button>
                        :
                        <Button className={classes.button} onClick={()=>setAdminCharacterProperties({...adminCharacterProperties, invisibility: true})}>Включить невидимость</Button>
                    }
                    {adminLvl >= AdminLevels.JuniorAdmin && adminCharacterProperties.godMode ?
                        <Button className={classes.button} onClick={()=>setAdminCharacterProperties({...adminCharacterProperties, godMode: false})}>Выключить godmode</Button>
                        :
                        <Button className={classes.button} onClick={()=>setAdminCharacterProperties({...adminCharacterProperties, godMode: true})}>Включить godmode</Button>
                    }
                </div>
            </Card>
        </Space>
    );
};

export default AdminPanel;