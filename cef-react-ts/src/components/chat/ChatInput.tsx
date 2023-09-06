import React from 'react';
import {Button, Form, Input, Space} from "antd";

type ChatInputProps = {
    onSubmit: (message: string) => void
    width: number
}


const ChatInput: React.FC<ChatInputProps> = ({onSubmit, width}) => {



    return (
        <Space style={{width:width, margin: 10}}>
            <Form
                layout={"inline"}
                name="basic"
                onFinish={(values) => onSubmit(values.text)}
                autoComplete="off"
            >
                <Form.Item
                    style={{width:width-140}}
                    label=""
                    name="text"
                >
                    <Input />
                </Form.Item>
                <Form.Item>
                    <Button type="primary" htmlType="submit">Отправить</Button>
                </Form.Item>
            </Form>
        </Space>
    );
};

export default ChatInput;