import React from 'react';
import {Space} from "antd";
import {ItemType} from "./Item";

export enum BoardTypeEnum {
    Other,
    Player,
    ClothesPlayer
}


export type BoardType = {
    type: BoardTypeEnum
    children?: React.ReactNode
}




const Board: React.FC<BoardType> = ({type,children}) => {

    return (
        <div style={{border: '1px solid #f0f0f0', borderRadius: '5px', width: 84, height: 84}}>
            {children}
        </div>
    );
};

export default Board;