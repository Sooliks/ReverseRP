import React, {useEffect, useState} from 'react';
import {Card, Space} from "antd";
import {Config} from "../../conf";
import Board, {BoardType, BoardTypeEnum} from "./Board";
import {ItemType} from "./Item";
import {useInventoryContext} from "./context/InventoryContextProvider";

//@ts-ignore
import {DragDropContext, DropResult} from "react-beautiful-dnd"


const Inventory : React.FC = () => {
    const [otherInventoryIsVisible,setOtherInventoryIsVisible] = useState<boolean>(false)
    const inventoryContext = useInventoryContext()

    const [inventoryPlayer,setInventoryPlayer] = useState<ItemType[]>([
        {id: 0, count: 5, description: 'Восполняет 40 еды', name: "burger", currentBoard: inventoryContext.inventory.boardsPlayer[0], index: 0},
        {id: 0, count: 5, description: 'Восполняет 40 еды', name: "бигтейсти", currentBoard: inventoryContext.inventory.boardsPlayer[1], index: 1}
    ])
    const [inventoryClothes,setInventoryClothes] = useState<ItemType[]>([])
    const [inventoryOther,setInventoryOther] = useState<ItemType[]>([])



    useEffect(()=>{
        let newBoards: BoardType[] = inventoryContext.inventory.boardsPlayer;
        //делаем клетки для айтемов
        for(let i = 0; i < 56; i++){
            newBoards = [...newBoards,{type: BoardTypeEnum.Player, idBoard: i}]
        }
        //делаем клетки одежды для айтемов
        let newBoardsClothes: BoardType[] = inventoryContext.inventory.boardsClothes;
        for(let i = 56; i < 63; i++){
            newBoardsClothes = [...newBoardsClothes,{type: BoardTypeEnum.ClothesPlayer, idBoard: i}]
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        //добавляем айтемы игрока в борды
        //заполняем борды игрока айтемами
        for (let i = 0; i< inventoryPlayer.length;i++){
            newBoards[inventoryPlayer[i].index].item = inventoryPlayer[i];
            if(newBoards[i].item!==undefined){
                // @ts-ignore
                newBoards[i].item.currentBoard = newBoards[inventoryPlayer[i].index];
            }
        }
        //заполняем борды одежды игрока айтемами
        for (let i = 0; i< inventoryClothes.length;i++){
            newBoardsClothes[inventoryClothes[i].index].item = inventoryClothes[i];
            if(newBoardsClothes[i].item!==undefined){
                // @ts-ignore
                newBoardsClothes[i].item.currentBoard = newBoardsClothes[inventoryClothes[i].index];
            }
        }
        inventoryContext.setInventory({...inventoryContext.inventory,boardsPlayer: newBoards, boardsClothes: newBoardsClothes})
    },[])

    const getTypeBoardById = (idBoard?: number): BoardTypeEnum =>{
        if(idBoard===undefined)return BoardTypeEnum.Player;

        if(idBoard<56){
            return BoardTypeEnum.Player;
        }
        if(idBoard>=56 && idBoard<63){
            return BoardTypeEnum.ClothesPlayer;
        }
        if(idBoard>62){
            return BoardTypeEnum.Other;
        }
        return BoardTypeEnum.Player;
    }


    const handleDragEnd = (result: DropResult) =>{
        if(!result.destination)return;
        const newBoardId: number = parseInt(result.destination.droppableId); // новый борд его id
        const itemDraggable = inventoryPlayer[parseInt(result.draggableId)]; // айтем который двигаем
        if(itemDraggable.currentBoard!==undefined){
            console.log(result)
            changeItem(newBoardId, itemDraggable)
        }
    }
    const changeItem = (newBoardId: number, itemDraggable: ItemType) => {
        let newBoards: BoardType[] = [];

        if(getTypeBoardById(newBoardId)===BoardTypeEnum.Player)newBoards = inventoryContext.inventory.boardsPlayer;
        if(getTypeBoardById(newBoardId)===BoardTypeEnum.ClothesPlayer)newBoards = inventoryContext.inventory.boardsClothes;
        if(getTypeBoardById(newBoardId)===BoardTypeEnum.Other)newBoards = inventoryContext.inventory.boardsOther;
        const indexNewBoard = newBoards.indexOf(newBoards.filter(b=>b.idBoard === newBoardId)[0])

        // @ts-ignore
        switch (itemDraggable.currentBoard.type){
            case BoardTypeEnum.Player:
                const clearingBoardsPlayer: BoardType[] = inventoryContext.inventory.boardsPlayer;
                console.log(clearingBoardsPlayer[clearingBoardsPlayer.indexOf(itemDraggable.currentBoard!)].item )
                // @ts-ignore
                clearingBoardsPlayer[clearingBoardsPlayer.indexOf(itemDraggable.currentBoard)].item = undefined;
                inventoryContext.setInventory({...inventoryContext.inventory,boardsPlayer: clearingBoardsPlayer})
                //newBoards = clearingBoardsPlayer;
                break
            case BoardTypeEnum.ClothesPlayer:
                const clearingBoardsClothesPlayer: BoardType[] = inventoryContext.inventory.boardsClothes;
                // @ts-ignore
                clearingBoardsClothesPlayer[clearingBoardsClothesPlayer.indexOf(itemDraggable.currentBoard)].item = undefined;
                inventoryContext.setInventory({...inventoryContext.inventory,boardsClothes: clearingBoardsClothesPlayer})
                //newBoards = clearingBoardsClothesPlayer;
                break
            case BoardTypeEnum.Other:
                const clearingBoardsOther: BoardType[] = inventoryContext.inventory.boardsOther;
                // @ts-ignore
                clearingBoardsOther[clearingBoardsOther.indexOf(itemDraggable.currentBoard)].item = undefined;
                inventoryContext.setInventory({...inventoryContext.inventory,boardsOther: clearingBoardsOther})
                //newBoards = clearingBoardsOther;
                break
        }
        newBoards[indexNewBoard].item = {id: 0, count: 5, description: 'dg', name: 'dgdg', index: 0}
        newBoards[indexNewBoard].item = itemDraggable;
        newBoards[indexNewBoard].item!.currentBoard = newBoards[indexNewBoard];

        if(getTypeBoardById(newBoardId)===BoardTypeEnum.Player)inventoryContext.setInventory({...inventoryContext.inventory,boardsPlayer: newBoards}) //перерисовываем инвентарь
        if(getTypeBoardById(newBoardId)===BoardTypeEnum.ClothesPlayer)inventoryContext.setInventory({...inventoryContext.inventory,boardsClothes: newBoards}) //перерисовываем инвентарь
        if(getTypeBoardById(newBoardId)===BoardTypeEnum.Other)inventoryContext.setInventory({...inventoryContext.inventory,boardsOther: newBoards})
    }


    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', justifyContent: 'center', alignItems: 'center'}}>
            <Space>
                <Card title={"Персонаж"}>
                    <DragDropContext onDragEnd={handleDragEnd}>
                        <Space style={{width: 1000, height: 700, justifyContent: 'space-around'}}>
                            <Card style={{width: 800, height: 700}}>
                                <Space wrap>
                                    {inventoryContext.inventory.boardsPlayer.map((board)=>
                                        <Board board={board}/>
                                    )}
                                </Space>
                            </Card>
                            <Card style={{height: 700}}>
                                <Space direction={"vertical"} style={{justifyContent: 'space-around'}} align={"center"}>
                                    {inventoryContext.inventory.boardsClothes.map((board)=>
                                        <Board board={board}/>
                                    )}
                                </Space>
                            </Card>
                        </Space>
                    </DragDropContext>
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