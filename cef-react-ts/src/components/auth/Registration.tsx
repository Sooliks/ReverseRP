import React from 'react';
import {Button, Form, Input, notification} from "antd";
import {Client} from "../../requests/Client";

const Registration : React.FC = () => {
    const onFinish = (values: any) => {
        Client.triggerServer("CEF::SERVER::ON_FINISH_REGISTRATION",values.login, values.email, values.password);
    };
    try {
        mp.events.add("SERVER::CEF::ERROR_REGISTRATION", (args) => {
            args = JSON.parse(args);
            notification.error({
                message: "Уведомление",
                description: args[0],
                placement: "top"
            })
        })
    }catch (e) {
        
    }

    return (
        <Form
            layout={"vertical"}
            onFinish={onFinish}
            autoComplete="off"
            style={{width: '300px'}}
        >
            <Form.Item
                label="Логин"
                name="login"
                rules={[
                    {
                        required: true,
                        message: 'Пожалуйста введите свой логин',
                    },
                    ({ getFieldValue }) => ({
                        validator(_, value) {
                            if (!value || getFieldValue('login').length >= 4) {
                                //setErrorValidateStatusRegLogin("validating");
                                return Promise.resolve();
                            }
                            //setErrorValidateStatusRegLogin("error");
                            return Promise.reject(new Error('Логин должен быть больше 3-х символов!'));
                        },
                    }),
                    ({ getFieldValue }) => ({
                        validator(_, value) {
                            let re = new RegExp("^\\w[\\w.]{4,12}\\w$");
                            if (!value || getFieldValue('login').match(re)) {
                                //setErrorValidateStatusRegLogin("validating");
                                return Promise.resolve();
                            }
                            //setErrorValidateStatusRegLogin("error");
                            return Promise.reject(new Error('Введите корректный логин!'));
                        },
                    }),
                ]}
            >
                <Input/>
            </Form.Item>
            <Form.Item
                label="Email"
                name="email"
                rules={[
                    {
                        type: 'email',
                        message: 'Введите корректный email!',
                    },
                    {
                        required: true,
                        message: 'Пожалуйста введите свою почту!',
                    },
                ]}
            >
                <Input/>
            </Form.Item>
            <Form.Item
                label="Пароль"
                name="password"
                rules={[
                    {
                        required: true,
                        message: 'Пожалуйста введите свой пароль!',
                    },
                    ({ getFieldValue }) => ({
                        validator(_, value) {
                            if (!value || getFieldValue('password').length >= 8) {
                                return Promise.resolve();
                            }
                            return Promise.reject(new Error('Пароль должен быть больше 7-и символов!'));
                        },
                    }),
                ]}
            >
                <Input.Password />
            </Form.Item>
            <Form.Item
                label="Подтвердите пароль"
                name="secondPassword"
                rules={[
                    {
                        required: true,
                        message: 'Пожалуйста подтвердите пароль',
                    },
                    ({ getFieldValue }) => ({
                        validator(_, value) {
                            if (!value || getFieldValue('password') === value) {
                                return Promise.resolve();
                            }
                            return Promise.reject(new Error('Пароли не совпадают!'));
                        },
                    }),
                ]}
            >
                <Input.Password />
            </Form.Item>
            <Form.Item>
                <Button type="primary" htmlType="submit" style={{width: '100%'}}>Зарегистрироваться</Button>
            </Form.Item>
        </Form>
    );
};

export default Registration;