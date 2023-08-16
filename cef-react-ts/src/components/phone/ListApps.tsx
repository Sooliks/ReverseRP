import React from 'react';
import {Space, Typography} from "antd";
import {CarOutlined, HomeOutlined} from "@ant-design/icons";

const {Text} = Typography;

type ListAppsProps = {
    onClickApp?: (name: string) => void
}

const ListApps: React.FC<ListAppsProps> = ({onClickApp}) => {
    type ListApps = {
        name: string
        icon: React.ReactNode
    }
    const styleIcon: React.CSSProperties = {
        color:"white", fontSize: '40px', margin: 0, border: '1px solid gray', borderRadius: '5px'
    }

    const listApps: ListApps[] = [
        {name: 'MyAuto', icon: <CarOutlined style={styleIcon}/>},
        {name: 'MyHome', icon: <HomeOutlined style={styleIcon}/>},
    ]



    return (
        <Space wrap style={{width: '100%', height: '100%', justifyContent: 'start'}} align={"start"}>
            {listApps.map((app)=>
                <Space
                    direction={"vertical"}
                    style={{width: 50, height: 50, alignItems: 'center', marginTop: 5}}
                    onClick={()=>onClickApp!(app.name)}
                >
                    {app.icon}
                    <Text style={{color:"white", margin: 0, fontSize: '10px'}}>{app.name}</Text>
                </Space>
            )}
        </Space>
    );
};

export default ListApps;