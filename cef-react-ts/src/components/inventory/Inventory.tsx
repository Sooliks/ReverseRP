import React, {useEffect, useState} from 'react';
import {Card, notification, Space} from "antd";
import {Config} from "../../conf";
import Board, {BoardType, BoardTypeEnum} from "./Board";
import {ItemType} from "./Item";
import {useInventoryContext} from "./context/InventoryContextProvider";


import {DragDropContext, DropResult} from "react-beautiful-dnd"
import {Client} from "../../requests/Client";


const Inventory : React.FC = () => {
    const [otherInventoryIsVisible,setOtherInventoryIsVisible] = useState<boolean>(true)
    const [titleOtherInventory,setTitleOtherInventory] = useState<string>('Багажник')

    const inventoryContext = useInventoryContext()

    const [inventoryPlayer,setInventoryPlayer] = useState<ItemType[]>([
        {id: 0, count: 5, description: 'Восполняет 40 еды', name: "burger", currentBoard: inventoryContext.inventory.boardsPlayer[0], index: 0},
        {id: 0, count: 5, description: 'Восполняет 40 еды', name: "бигтейсти", currentBoard: inventoryContext.inventory.boardsPlayer[1], index: 1},
        {id: 5, count: 5, description: 'Восполняет 40 еды', name: "Телефон", currentBoard: inventoryContext.inventory.boardsPlayer[2], index: 2}
    ])
    const [inventoryClothes,setInventoryClothes] = useState<ItemType[]>([])
    const [inventoryOther,setInventoryOther] = useState<ItemType[]>([])



    useEffect(()=>{
        Client.callProcServer<any>("RPC::CEF:SERVER:GetInventory").then(data=>console.log(data)).catch(e=>console.log(e));




        //console.log(Client.callProcServer<string>("RPC::CEF:SERVER:GetInventory"))
        
        //делаем клетки для айтемов
        let newBoards: BoardType[] = inventoryContext.inventory.boardsPlayer;
        for(let i = 0; i < 56; i++){
            newBoards = [...newBoards,{type: BoardTypeEnum.Player, idBoard: i}]
        }
        let newBoardsClothes: BoardType[] = inventoryContext.inventory.boardsClothes;
        for(let i = 56; i < 63; i++){
            newBoardsClothes = [...newBoardsClothes,{type: BoardTypeEnum.ClothesPlayer, idBoard: i}]
        }
        let newBoardsOther: BoardType[] = inventoryContext.inventory.boardsOther;
        for(let i = 63; i < 63+21; i++){
            newBoardsOther = [...newBoardsOther,{type: BoardTypeEnum.Other, idBoard: i}]
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
        //заполняем борды другого инвентаря айтемами
        for (let i = 0; i < inventoryOther.length;i++){
            newBoardsOther[inventoryOther[i].index].item = inventoryOther[i];
            if(newBoardsOther[i].item!==undefined){
                // @ts-ignore
                newBoardsOther[i].item.currentBoard = newBoardsOther[inventoryOther[i].index];
            }
        }
        inventoryContext.setInventory({...inventoryContext.inventory,boardsPlayer: newBoards, boardsClothes: newBoardsClothes, boardsOther: newBoardsOther})
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
            changeItem(newBoardId, itemDraggable)
        }
    }
    const changeItem = (newBoardId: number, itemDraggable: ItemType) => {
        let newBoards: BoardType[] = [];
        if(getTypeBoardById(newBoardId)===BoardTypeEnum.Player)newBoards = inventoryContext.inventory.boardsPlayer;
        if(getTypeBoardById(newBoardId)===BoardTypeEnum.ClothesPlayer)newBoards = inventoryContext.inventory.boardsClothes;
        if(getTypeBoardById(newBoardId)===BoardTypeEnum.Other)newBoards = inventoryContext.inventory.boardsOther;
        const indexNewBoard = newBoards.indexOf(newBoards.filter(b=>b.idBoard === newBoardId)[0])

        if(newBoards[indexNewBoard].item!==undefined){
            return
        }

        switch (itemDraggable.currentBoard!.type){
            case BoardTypeEnum.Player:
                const clearingBoardsPlayer: BoardType[] = inventoryContext.inventory.boardsPlayer;
                clearingBoardsPlayer[clearingBoardsPlayer.indexOf(itemDraggable.currentBoard!)].item = undefined;
                inventoryContext.setInventory({...inventoryContext.inventory,boardsPlayer: clearingBoardsPlayer})
                break
            case BoardTypeEnum.ClothesPlayer:
                const clearingBoardsClothesPlayer: BoardType[] = inventoryContext.inventory.boardsClothes;
                clearingBoardsClothesPlayer[clearingBoardsClothesPlayer.indexOf(itemDraggable.currentBoard!)].item = undefined;
                inventoryContext.setInventory({...inventoryContext.inventory,boardsClothes: clearingBoardsClothesPlayer})
                break
            case BoardTypeEnum.Other:
                const clearingBoardsOther: BoardType[] = inventoryContext.inventory.boardsOther;
                clearingBoardsOther[clearingBoardsOther.indexOf(itemDraggable.currentBoard!)].item = undefined;
                inventoryContext.setInventory({...inventoryContext.inventory,boardsOther: clearingBoardsOther})
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
        <DragDropContext onDragEnd={handleDragEnd}>
            <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', justifyContent: 'center', alignItems: 'center'}}>
                <Space>
                    <Card title={"Персонаж"}>
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
                    </Card>
                </Space>
                {otherInventoryIsVisible &&
                    <Space>
                        <Card style={{width: 350, height: 805}} title={titleOtherInventory}>
                            <Space wrap align={"center"} style={{width: '100%', height: '100%', justifyContent: 'center'}}>
                                {inventoryContext.inventory.boardsOther.map((board)=>
                                    <Board board={board}/>
                                )}
                            </Space>
                        </Card>
                    </Space>
                }
            </Space>
        </DragDropContext>
    );
};

export default Inventory;