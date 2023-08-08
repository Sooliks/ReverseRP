import React, {useState} from 'react';
import {Button, Form, Input, InputNumber, Modal, Select, Space} from "antd";
import {CreateCharacterType, useCreateCharacterContext} from "../context/CreateCharacterContextProvider";
import {Client} from "../../../../requests/Client";

type FinishType = {
    onHide: () => void
}


const Finish: React.FC<FinishType> = ({onHide}) => {
    const characterContext = useCreateCharacterContext()

    const handleClickFinish = (values: any) => {
        const newCharacter: CreateCharacterType = characterContext.character;
        newCharacter.firstName = values.firstName;
        newCharacter.lastName = values.lastName;
        newCharacter.birth = values.birth;
        newCharacter.origin = values.origin;
        Client.triggerServer("CEF::SERVER::ON_FINISH_CREATE_CHARACTER",JSON.stringify(newCharacter))
    }

    return (
        <Modal
            title=""
            centered
            open
            onCancel={() => onHide()}
            width={600}
            footer={[]}
        >
            <Space style={{width: '100%',marginTop: 50, marginBottom: 50, justifyContent: 'center', alignItems: 'center'}}>
                <Form
                    layout={"vertical"}
                    onFinish={handleClickFinish}
                    autoComplete="off"
                    style={{width: '300px'}}
                >
                    <Form.Item
                        label="Имя"
                        name="firstName"
                        rules={[
                            {
                                required: true,
                                message: 'Пожалуйста введите имя!',
                            },
                        ]}
                    >
                        <Input/>
                    </Form.Item>
                    <Form.Item
                        label="Фамилия"
                        name="lastName"
                        rules={[
                            {
                                required: true,
                                message: 'Пожалуйста введите фамилию!',
                            },
                        ]}
                    >
                        <Input/>
                    </Form.Item>
                    <Form.Item
                        label="Возраст"
                        name="birth"
                        rules={[
                            {
                                required: true,
                                message: 'Пожалуйста введите фамилию!',
                            },
                        ]}
                    >
                        <InputNumber min={18} max={50} defaultValue={18} />
                    </Form.Item>
                    <Form.Item
                        label="Город"
                        name="origin"
                        rules={[
                            {
                                required: true,
                                message: 'Пожалуйста введите фамилию!',
                            },
                        ]}
                    >
                        <Select
                            style={{width: '100%'}}
                            placeholder=""
                            className={"origin"}
                            defaultValue={1}
                            options={[
                                { value: 1, label: 'Los Santos' },
                                { value: 2, label: 'Sandy Shores' },
                                { value: 3, label: 'Paleto Bay' },
                            ]}
                            filterOption={(input, option) =>
                                (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
                            }
                        />
                    </Form.Item>
                    <Form.Item>
                        <Button type="primary" htmlType="submit" style={{width: '100%'}}>Создать</Button>
                    </Form.Item>
                </Form>
            </Space>
        </Modal>
    );
};

export default Finish;