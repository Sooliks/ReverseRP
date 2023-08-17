import React from 'react';
import {Card, Space, Typography} from "antd";
import DefaultColorPalette from "./DefaultColorPalette";

const {Title} = Typography;


type ReverseColorPickerProps = {
    onPickColor: (index: number, hexColor?: string) => void
    title?: string
    width?: number
}
const ReverseColorPicker: React.FC<ReverseColorPickerProps> = ({onPickColor, title, width}) => {
    return (
        <Card>
            <Space direction={"vertical"} align={"center"} style={{justifyContent: 'center'}}>
                {title && <Title style={{textAlign: 'center'}} level={4}>{title}</Title>}
                <Space direction={"horizontal"} style={{width: width ? width : 300}} align={"center"}>
                    <DefaultColorPalette onPickColor={onPickColor}/>
                </Space>
            </Space>
        </Card>
    );
};

export default ReverseColorPicker;