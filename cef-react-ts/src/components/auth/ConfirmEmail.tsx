import React, {useState} from 'react';
import ModalWithInputForm from "../../ui/ModalWithInputForm";
import {notification} from "antd";
import {Client} from "../../requests/Client";

const ConfirmEmail: React.FC = () => {
    const [isOpen,setIsOpen] = useState<boolean>(true)
    return (
        <div>
            <ModalWithInputForm labelInput={"Код подтверждения отправлен на почту"} labelButton={"Проверить"} isOpen={isOpen} onCancel={()=>{}} onSubmit={(value)=>{
                if(isNaN(parseInt(value))){
                    notification.error({
                        placement: 'top',
                        description: 'Введите число!',
                        message: "Уведомление"
                    })
                    return
                }
                Client.callProcServer<"success" | "expired" | "notfound">("RPC::CEF::SERVER:CONFIRM_ACCOUNT_EMAIL", value).then(data=>{
                    switch (data){
                        case "expired":
                            notification.error({
                                placement: 'top',
                                description: 'Данный код истек, новый отправлен на почту!',
                                message: "Уведомление"
                            })
                            break
                        case "notfound":
                            notification.error({
                                placement: 'top',
                                description: 'Неверный код!',
                                message: "Уведомление"
                            })
                            break
                        case "success":
                            break
                    }
                })
            }}/>
        </div>
    );
};

export default ConfirmEmail;