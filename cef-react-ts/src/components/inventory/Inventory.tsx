import React, {useEffect, useState} from 'react';
import {Card, Space} from "antd";
import {Config} from "../../conf";
import Board, {BoardType, BoardTypeEnum} from "./Board";
import {ItemType} from "./Item";
import {InventoryType, useInventoryContext} from "./context/InventoryContextProvider";

//@ts-ignore
import {DragDropContext, DropResult} from "react-beautiful-dnd"


const Inventory : React.FC = () => {
    const [otherInventoryIsVisible,setOtherInventoryIsVisible] = useState<boolean>(false)

    const inventoryContext = useInventoryContext()
    /*const [boards,setBoards] = useState<BoardType[]>([]);
    const [boardsClothes,setBoardsClothes] = useState<BoardType[]>([])*/

    const [inventoryPlayer,setInventoryPlayer] = useState<ItemType[]>([
        {id: 0, count: 5, description: 'Восполняет 40 еды', name: "burger", currentBoard: inventoryContext.inventory.boardsPlayer[0], index: 0}
    ])
    const [inventoryOther,setInventoryOther] = useState<ItemType[]>([])

    const [state,setState] = useState(0)

    useEffect(()=>{
        let newBoards: BoardType[] = inventoryContext.inventory.boardsPlayer;
        //делаем клетки для айтемов
        for(let i = 0; i < 56; i++){
            newBoards = [...newBoards,{type: BoardTypeEnum.Player, idBoard: i}]
        }
        //делаем клетки одежды для айтемов
        let newBoardsClothes: BoardType[] = inventoryContext.inventory.boardsClothes;
        for(let i = 0; i < 7; i++){
            newBoardsClothes = [...newBoardsClothes,{type: BoardTypeEnum.ClothesPlayer, idBoard: i}]
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        //добавляем айтемы игрока в борды
        for (let i = 0; i< inventoryPlayer.length;i++){
            newBoards[i].item = inventoryPlayer[i];
            if(newBoards[i].item!==undefined){
                // @ts-ignore
                newBoards[i].item.currentBoard = newBoards[i];
            }
        }
        inventoryContext.setInventory({...inventoryContext.inventory,boardsPlayer: newBoards, boardsClothes: newBoardsClothes})
    },[])



    const handleDragEnd = (result: DropResult) =>{
        if(!result.destination)return;
        let newBoards: BoardType[] = inventoryContext.inventory.boardsPlayer;
        const itemDraggable = inventoryPlayer[parseInt(result.draggableId)];//айтем который двигаем
        let lastBoardIndex: number; //прошлый борд
        if(itemDraggable.currentBoard!==undefined){
            lastBoardIndex = inventoryContext.inventory.boardsPlayer.indexOf(itemDraggable.currentBoard)
            newBoards[lastBoardIndex].item = undefined; //удаляем из прошлого борда айтем
        }
        const newBoardId: number = parseInt(result.destination?.droppableId); // новый борд его id
        newBoards[newBoardId].item = itemDraggable; //устанавливаем в новый борд перемещенный айтем
        // @ts-ignore
        newBoards[newBoardId].item.currentBoard = newBoards[newBoardId]; // устанавливаем этому айтему новый борд
        inventoryContext.setInventory({...inventoryContext.inventory,boardsPlayer: newBoards}) //перерисовываем инвентарь
    }

    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', justifyContent: 'center', alignItems: 'center'}}>
            <Space>
                <Card title={"Персонаж"}>
                    <Space style={{width: 1000, height: 700, justifyContent: 'space-around'}}>
                        <Card style={{width: 800, height: 700}}>
                            <DragDropContext onDragEnd={handleDragEnd}>
                                <Space wrap>
                                    {inventoryContext.inventory.boardsPlayer.map((board)=>
                                        <Board board={board} onChangeItem={(b, currentItem)=>{

                                        }}/>
                                    )}
                                </Space>
                            </DragDropContext>
                        </Card>
                        <Card style={{height: 700}}>
                            <DragDropContext onDragEnd={handleDragEnd}>
                                <Space direction={"vertical"} style={{justifyContent: 'space-around'}} align={"center"}>
                                    {inventoryContext.inventory.boardsClothes.map((board)=>
                                        <Board board={board} onChangeItem={(b, currentItem)=>{

                                        }}/>
                                    )}
                                </Space>
                            </DragDropContext>
                        </Card>
                    </Space>
                </Card>
            </Space>
            {otherInventoryIsVisible &&
                <Space>

                </Space>
            }
        </Space>
    );
};

export default Inventory;