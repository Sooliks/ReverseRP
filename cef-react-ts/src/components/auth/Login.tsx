import React from 'react';
import {Button, Checkbox, Form, Input, notification, Typography} from "antd";
import {LockOutlined, UserOutlined} from "@ant-design/icons";
import {Client} from "../../requests/Client";
import {useNavigationContext} from "../../context/NavigationContextProvider";
import hud from "../hud/Hud";

const { Link } = Typography;


const Login : React.FC = () => {
    const onFinish = (values: any) => {
        Client.triggerServer("CEF::SERVER::ON_FINISH_LOGIN",values.login,values.password, values.remember)
    };
    try {
        mp.events.add("SERVER::CEF::ERROR_LOGIN", (text) => {
            console.log(text+" LOOOOOOOOOOOG");
            notification.error({
                message: "Уведомление",
                description: text,
                placement: "top"
            })
        })
    }catch (e) {
        
    }

    return (
        <Form
            name="normal_login"
            initialValues={{ remember: true }}
            onFinish={onFinish}
            style={{width: '300px'}}
        >
            <Form.Item
                name="login"
                rules={[{ required: true, message: 'Пожалуйста введите логин!' }]}
            >
                <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Логин" />
            </Form.Item>
            <Form.Item
                name="password"
                rules={[{ required: true, message: 'Пожалуйста введите пароль!' }]}
            >
                <Input
                    prefix={<LockOutlined className="site-form-item-icon" />}
                    type="password"
                    placeholder="Пароль"
                />
            </Form.Item>
            <Form.Item>
                <Form.Item name="remember" valuePropName="checked" noStyle>
                    <Checkbox>Запомнить меня</Checkbox>
                </Form.Item>
                <Link href="" style={{float: "right"}}>
                    Забыли пароль
                </Link>
            </Form.Item>

            <Form.Item>
                <Button type="primary" htmlType="submit" style={{width: '100%'}}>
                    Войти
                </Button>
            </Form.Item>
        </Form>
    );
};

export default Login;

