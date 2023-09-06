import React from 'react';
import {Space} from "antd";
import {Config} from "../../conf";
import ChatInput from "./ChatInput";


type ChatProps = {
    type: 'passive' | 'active'
}

const Chat: React.FC<ChatProps> = ({type}) => {
    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', alignItems: 'flex-start', justifyContent: 'flex-start'}}>
            <Space style={{backgroundColor: 'rgba(206,201,203,0.2)', width: 560, height: 300, justifyContent: 'space-between', borderRadius: '5px'}} direction={"vertical"}>
                <div/>
                {type === "active" && <ChatInput onSubmit={()=>{}} width={560}/>}
            </Space>
        </Space>
    );
};

export default Chat;