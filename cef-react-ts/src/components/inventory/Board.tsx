import React, {useState} from 'react';
import {Space} from "antd";
import Item, {ItemType} from "./Item";
import {InventoryType, useInventoryContext} from "./context/InventoryContextProvider";

import {Droppable, Draggable} from "react-beautiful-dnd"

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
}




const Board: React.FC<BoardProps> = ({board}) => {


    return (
        <Droppable droppableId={board.idBoard.toString()} key={board.idBoard}>
            {(provided: any) =>(
                <div
                    style={{border: '1px solid #f0f0f0', borderRadius: '5px', width: 84, height: 84}}
                    {...provided.droppableProps}
                    ref={provided.innerRef}
                >
                    {provided.placeholder}
                    {board.item !== undefined &&
                        <Draggable draggableId={board.item.index.toString()} key={board.item.index} index={board.item.index}>
                            {(provided: any) => (
                                <div ref={provided.innerRef} {...provided.draggableProps} {...provided.dragHandleProps} onMouseDown={(e)=>e.preventDefault()}>
                                    {provided.placeholder}
                                    {board.item !== undefined &&
                                        <Item index={board.item.index} id={board.item.id} name={board.item.name} count={board.item.count}
                                              description={board.item.description}/>

                                    }
                                </div>
                            )}
                        </Draggable>
                    }
                </div>
            )}
        </Droppable>
    );
};

export default Board;