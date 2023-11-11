import React from 'react';
import {Button, Form, Input, Modal} from "antd";


type ModalWithInputFormProps = {
    labelInput: string
    labelButton: string
    isOpen: boolean
    onCancel: () => void
    onSubmit: (value: string) => void
}

const ModalWithInputForm: React.FC<ModalWithInputFormProps> = ({labelInput, labelButton, isOpen = true, onCancel = () => {}, onSubmit}) => {
    return (
        <Modal
            open={isOpen}
            onCancel={()=>{
                onCancel();
                isOpen = false;
            }}
            footer={[]}
        >
            <Form
                layout={"vertical"}
                name="basic"
                onFinish={(values: any) => onSubmit(values.value)}
                autoComplete="off"
            >
                <Form.Item
                    label={labelInput}
                    name="value"
                    rules={[
                        {
                            required: true,
                            message: 'Заполните поле',
                        },
                    ]}
                >
                    <Input />
                </Form.Item>
                <Form.Item>
                    <Button type="primary" htmlType="submit">{labelButton}</Button>
                </Form.Item>
            </Form>
        </Modal>
    );
};

export default ModalWithInputForm;