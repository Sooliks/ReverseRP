import React, {useEffect, useState} from 'react';
import {Card, notification, Space} from "antd";
import {Config} from "../../conf";
import Board, {BoardType, BoardTypeEnum} from "./Board";
import {ItemType} from "./Item";
import {useInventoryContext} from "./context/InventoryContextProvider";


import {DragDropContext, DropResult} from "react-beautiful-dnd"
import {Client} from "../../requests/Client";

type IncomingInventory = {
    count: number
    name: string,
    description: string,
    idItem: number,
    hash: number,
    type: string
}

const Inventory : React.FC = () => {
    const [otherInventoryIsVisible,setOtherInventoryIsVisible] = useState<boolean>(true)
    const [titleOtherInventory,setTitleOtherInventory] = useState<string>('Багажник')

    const inventoryContext = useInventoryContext()

    const [inventoryPlayer,setInventoryPlayer] = useState<ItemType[]>([])
    const [inventoryClothes,setInventoryClothes] = useState<ItemType[]>([])
    const [inventoryOther,setInventoryOther] = useState<ItemType[]>([])

    mp.events.add("SERVER::CEF:UPDATE_INVENTORY_PLAYER",(args)=>{
        args = JSON.parse(args);
        const data: IncomingInventory[] = args[0];
        updateInventory(data);
    })

    useEffect(()=>{
        Client.callProcServer<string>("RPC::CEF:SERVER:GetInventoryPlayer").then(json=>{
            const data: IncomingInventory[] = JSON.parse(json);
            updateInventory(data);
        })
    },[])

    const updateInventory = (invPlayer?: IncomingInventory[],invClothes?: IncomingInventory[], invOther?: IncomingInventory[]) => {
        //делаем клетки для айтемов
        let newBoards: BoardType[] = [];
        for(let i = 0; i < 56; i++){
            newBoards = [...newBoards,{type: BoardTypeEnum.Player, idBoard: i}]
        }
        let newBoardsClothes: BoardType[] = [];
        for(let i = 56; i < 63; i++){
            newBoardsClothes = [...newBoardsClothes,{type: BoardTypeEnum.ClothesPlayer, idBoard: i}]
        }
        let newBoardsOther: BoardType[] = [];
        for(let i = 63; i < 63+21; i++){
            newBoardsOther = [...newBoardsOther,{type: BoardTypeEnum.Other, idBoard: i}]
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        if(invPlayer!==undefined) {
            let newInventoryPlayer: ItemType[] = [];
            for (let i = 0; i < invPlayer.length; i++) {
                newInventoryPlayer[i] = {
                    id: invPlayer[i].idItem,
                    count: invPlayer[i].count,
                    description: invPlayer[i].description,
                    name: invPlayer[i].name,
                    currentBoard: inventoryContext.inventory.boardsPlayer[i],
                    index: i
                }
            }
            //заполняем борды игрока айтемами
            for (let i = 0; i < newInventoryPlayer.length; i++) {
                newBoards[newInventoryPlayer[i].index].item = newInventoryPlayer[i];
                if (newBoards[i].item !== undefined) {
                    // @ts-ignore
                    newBoards[i].item.currentBoard = newBoards[newInventoryPlayer[i].index];
                }
            }
            setInventoryPlayer(newInventoryPlayer);
        }
        if(invClothes!==undefined){
            let newInventoryClothes: ItemType[] = [];
            for (let i = 0; i < invClothes.length; i++) {
                newInventoryClothes[i] = {
                    id: invClothes[i].idItem,
                    count: invClothes[i].count,
                    description: invClothes[i].description,
                    name: invClothes[i].name,
                    currentBoard: inventoryContext.inventory.boardsPlayer[i],
                    index: i
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
            setInventoryClothes(newInventoryClothes);
        }
        if(invOther!==undefined){
            let newInventoryOther: ItemType[] = [];
            for (let i = 0; i < invOther.length; i++) {
                newInventoryOther[i] = {
                    id: invOther[i].idItem,
                    count: invOther[i].count,
                    description: invOther[i].description,
                    name: invOther[i].name,
                    currentBoard: inventoryContext.inventory.boardsPlayer[i],
                    index: i
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
            setInventoryOther(newInventoryOther);
        }
        //inventoryContext.setInventory({...inventoryContext.inventory,boardsPlayer: newBoards, boardsClothes: newBoardsClothes, boardsOther: newBoardsOther})
        inventoryContext.setInventory({boardsPlayer: newBoards, boardsClothes: newBoardsClothes, boardsOther: newBoardsOther})
    }

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