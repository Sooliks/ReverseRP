import React, {useEffect, useState} from 'react';
import {useNavigate, useNavigation, useParams} from "react-router-dom";
import {Config} from "../../conf";
import {Button, Card, Modal, Space} from "antd";
import {CloseOutlined, ExclamationCircleOutlined} from "@ant-design/icons";
import {Client} from "../../requests/Client";
import Information from "../../ui/Information";

type InformationOfBusinessParams = {
    id: string
}

type BusinessType = {
    OwnerName: string
    GosPrice: number
    Type: string
}
const { confirm } = Modal;

const InformationOfBusiness: React.FC = () => {
    const params = useParams<InformationOfBusinessParams>();
    const [modal, contextHolder] = Modal.useModal();

    const[business,setBusiness] = useState<BusinessType>({
        OwnerName: 'Нету', GosPrice: 1000000, Type: "Market"
    })
    useEffect(()=>{
        Client.callProcServer<string>("RPC::CEF::SERVER:GetInformationBusiness", params.id).then(data=>{
            setBusiness(JSON.parse(data));
        })
    },[])
    const navigation = useNavigate()
    const handleClickBuy = () => {
        confirm({
            title: 'Подтверждение',
            icon: <ExclamationCircleOutlined />,
            content: `Вы действительно хотите купить бизнес за ${business.GosPrice} ?`,
            okText: 'Купить',
            cancelText: 'Отмена',
            open: true,
            onOk(){
                Client.triggerServer("CEF::SERVER:ON_BUY_BUSINESS", params.id)
                setTimeout(()=>{
                    navigation(`/informationbusiness/${params.id}`)
                },1000)
                Client.closeWindow()
            },
        });
    }

    return (
        <Space style={{position:'absolute',width:Config.screenResolution.width, height:Config.screenResolution.height, justifyContent: 'center'}}>
            <Card title={"Информация"} extra={<Button icon={<CloseOutlined/>} onClick={()=>Client.closeWindow()}/>}>
                <div style={{width: '40vw', height: '20vh'}}>
                    <Information text={["Владелец: ", "Гос. цена: ", "Тип: "]} data={[business.OwnerName, business.GosPrice, business.Type]}/>
                    {business.OwnerName === "Нету" &&
                        <Button
                            type={"primary"}
                            style={{width: '100%', left: "50%", right: "50%", transform: "translate(-50%,-50%)", top: '50%'}}
                            onClick={handleClickBuy}
                        >
                            Купить
                        </Button>
                    }
                </div>
            </Card>
        </Space>
    );
};

export default InformationOfBusiness;