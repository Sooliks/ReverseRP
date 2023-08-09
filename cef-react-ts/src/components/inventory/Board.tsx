import React, {useState} from 'react';
import {Space} from "antd";
import Item, {ItemType} from "./Item";

export enum BoardTypeEnum {
    Other,
    Player,
    ClothesPlayer
}


export type BoardType = {
    type: BoardTypeEnum
    item?: ItemType
    idBoard: number
}

type BoardProps = {
    board: BoardType
    onChangeItem: (board: BoardType,currentItem?: ItemType) => void
}




const Board: React.FC<BoardProps> = ({board,onChangeItem}) => {
    const [currentItem,setCurrentItem] = useState<ItemType>()

    const dragStartHandler = (e: any, board: BoardType) => {
        if(board.item === undefined){
            e.preventDefault();
            return
        }
        setCurrentItem(board.item);
        console.log('start', board.item)
    }
    const dragLeaveHandler = (e: any) => {
        e.target.style.background = 'white'
    }
    const dragEndHandler = (e: any) => {
        e.target.style.background = 'white'
    }
    const dragOverHandler = (e: any) => {
        e.preventDefault();
        e.target.style.background = 'lightgray'
    }
    const dropHandler = (e: any, board: BoardType) => {
        e.preventDefault();
        e.target.style.background = 'white'
        onChangeItem(board,currentItem);
        console.log('drop', board)
    }

    return (
        <div
            style={{border: '1px solid #f0f0f0', borderRadius: '5px', width: 84, height: 84}}
            draggable
            onDragStart={(e)=>dragStartHandler(e,board)}
            onDragLeave={(e)=>dragLeaveHandler(e)}
            onDragEnd={(e)=>dragEndHandler(e)}
            onDragOver={(e)=>dragOverHandler(e)}
            onDrop={(e)=>dropHandler(e,board)}
        >
            {board.item !== undefined &&
                <Item id={board.item.id} name={board.item.name} count={board.item.count} description={board.item.description}/>
            }
        </div>
    );
};

export default Board;