import React, {useEffect, useState} from 'react';
import {Card, Space} from "antd";
import {Config} from "../../conf";
import Board, {BoardType, BoardTypeEnum} from "./Board";
import Item, {ItemType} from "./Item";


const Inventory : React.FC = () => {
    const [otherInventoryIsVisible,setOtherInventoryIsVisible] = useState<boolean>(false)

    const [boards,setBoards] = useState<BoardType[]>([]);
    const [boardsClothes,setBoardsClothes] = useState<BoardType[]>([])

    const [inventoryPlayer,setInventoryPlayer] = useState<ItemType[]>([
        {id: 0, count: 5, description: 'abobs', name: "burger"}
    ])
    const [inventoryOther,setInventoryOther] = useState<ItemType[]>([])


    useEffect(()=>{
        let newBoards: BoardType[] = []
        //делаем клетки для айтемов
        for(let i = 0; i < 56; i++){
            newBoards = [...newBoards,{type: BoardTypeEnum.Player}]
        }
        //делаем клетки одежды для айтемов
        let newBoardsClothes: BoardType[] = []
        for(let i = 0; i < 7; i++){
            newBoardsClothes = [...newBoardsClothes,{type: BoardTypeEnum.ClothesPlayer}]
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        for (let i = 0; i<inventoryPlayer.length;i++){
            newBoards[i].children = <Item id={inventoryPlayer[i].id} name={inventoryPlayer[i].name} description={inventoryPlayer[i].description} count={inventoryPlayer[i].count}/>
        }

        setBoards(newBoards)
        setBoardsClothes(newBoardsClothes)
    },[])

    return (
        <Space style={{width: Config.screenResolution.width, height: Config.screenResolution.height, position: 'absolute', justifyContent: 'center', alignItems: 'center'}}>
            <Space>
                <Card title={"Персонаж"}>
                    <Space style={{width: 1000, height: 700, justifyContent: 'space-around'}}>
                        <Card style={{width: 800, height: 700}}>
                            <Space wrap>
                                {boards.map((board)=>
                                    <Board type={board.type}>
                                        {board.children}
                                    </Board>
                                )}
                            </Space>
                        </Card>
                        <Card style={{height: 700}}>
                            <Space direction={"vertical"} style={{justifyContent: 'space-around'}} align={"center"}>
                                {boardsClothes.map((board)=>
                                    <Board type={board.type}>
                                        {board.children}
                                    </Board>
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