import React, {CSSProperties} from 'react';
import {Space, Typography} from "antd";


type InformationProps = {
    title?: string
    text: string[]
    data: any[]
    style?: CSSProperties
}
const {Title, Text} = Typography;

const Information: React.FC<InformationProps> = ({title, text, data,style}) => {

    return (
        <div style={style}>
            <Space direction={"vertical"}>
                {title !== undefined && <Title level={4}>{title}</Title>}
                {text.map((text, index)=>
                    <Space>
                        <Text type={"secondary"}>{text}</Text>
                        <Text>{data[index]}</Text>
                    </Space>
                )}
            </Space>
        </div>
    );
};

export default Information;