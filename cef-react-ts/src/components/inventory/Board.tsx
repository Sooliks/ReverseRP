import React from 'react';
import {Space} from "antd";
import {ItemType} from "./Item";

enum BoardTypeEnum {
    Other,
    Player,
}


type BoardType = {
    type: BoardTypeEnum
    item: React.ComponentType
    isExistItem: boolean
}




const Board: React.FC<BoardType> = ({type,item: Item,isExistItem}) => {

    return (
        <Space>
            {isExistItem &&
                <Item/>
            }
        </Space>
    );
};

export default Board;