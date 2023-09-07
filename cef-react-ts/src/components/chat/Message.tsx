import React from 'react';
import {Space, Typography} from "antd";

const {Text} = Typography;

type MessageProps = {
    name: string
    message: string
    idPlayer: number
}

const Message: React.FC<MessageProps> = ({name, message, idPlayer}) => {

    return (
        <Space>
            <Text>{name + ` [${idPlayer}] `}</Text>
            <Text>{message}</Text>
        </Space>
    );
};

export default Message;