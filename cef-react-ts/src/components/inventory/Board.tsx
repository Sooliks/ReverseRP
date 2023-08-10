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
    onChangeItem: (board: BoardType,currentItem?: ItemType) => void
}




const Board: React.FC<BoardProps> = ({board,onChangeItem}) => {
    const inventoryContext = useInventoryContext()
    const dragStartHandler = (e: any, board: BoardType) => {
        if(board.item === undefined){
            e.preventDefault();
            return
        }
        const newInventory: InventoryType = inventoryContext.inventory;
        newInventory.currentItem = board.item;
        inventoryContext.setInventory(newInventory)
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
        onChangeItem(board,inventoryContext.inventory.currentItem);
    }

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
                        <Draggable draggableId={board.item.id.toString()} key={board.item.id} index={board.item.id}>
                            {(provided: any) => (
                                <div ref={provided.innerRef} {...provided.draggableProps} {...provided.dragHandleProps}>
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