import React, {useEffect, useState} from 'react';
import {Card, Space} from "antd";
import {Config} from "../../conf";
import Board, {BoardType, BoardTypeEnum} from "./Board";
import {ItemType} from "./Item";
import {InventoryType, useInventoryContext} from "./context/InventoryContextProvider";



const Inventory : React.FC = () => {
    const [otherInventoryIsVisible,setOtherInventoryIsVisible] = useState<boolean>(false)

    const inventoryContext = useInventoryContext()
    /*const [boards,setBoards] = useState<BoardType[]>([]);
    const [boardsClothes,setBoardsClothes] = useState<BoardType[]>([])*/

    const [inventoryPlayer,setInventoryPlayer] = useState<ItemType[]>([
        {id: 0, count: 5, description: 'Восполняет 40 еды', name: "burger"}
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
            newBoards[i].item.currentBoard = newBoards[i];
        }
        inventoryContext.setInventory({...inventoryContext.inventory,boardsPlayer: newBoards, boardsClothes: newBoardsClothes})
    },[])


    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', justifyContent: 'center', alignItems: 'center'}}>
            <Space>
                <Card title={"Персонаж"}>
                    <Space style={{width: 1000, height: 700, justifyContent: 'space-around'}}>
                        <Card style={{width: 800, height: 700}}>
                            <Space wrap>
                                {inventoryContext.inventory.boardsPlayer.map((board)=>
                                    <Board board={board} onChangeItem={(b, currentItem)=>{
                                        const newBoards: BoardType[] = inventoryContext.inventory.boardsPlayer;
                                        const index = inventoryContext.inventory.boardsPlayer.indexOf(b);
                                        const lastBoardIndex = inventoryContext.inventory.boardsPlayer.indexOf(currentItem.currentBoard)
                                        newBoards[lastBoardIndex].item = undefined;
                                        newBoards[index].item = currentItem;
                                        currentItem.currentBoard = newBoards[index];
                                        inventoryContext.setInventory({...inventoryContext.inventory,boardsPlayer: newBoards})
                                    }}/>
                                )}
                            </Space>
                        </Card>
                        <Card style={{height: 700}}>
                            <Space direction={"vertical"} style={{justifyContent: 'space-around'}} align={"center"}>
                                {inventoryContext.inventory.boardsClothes.map((board)=>
                                    <Board board={board} onChangeItem={(b, currentItem)=>{

                                    }}/>
                                )}
                            </Space>
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