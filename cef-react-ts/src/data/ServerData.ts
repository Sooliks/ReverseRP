import {VehicleType} from "../types/vehicleType";
import {ItemType} from "../types/itemType";

export class ServerData {
    static player = {
        id: 0,
        money: 0,
        moneyBank: 0
    }
    static vehiclesTypes: VehicleType[] = [

    ];
    static itemsTypes: ItemType[] = []
    static getTypeGasById = (id: number): string =>{
        switch (id){
            case 0:
                return "Eco"
            case 1:
                return "Premium"
            case 2:
                return "Lux"
            case 3:
                return "Electric"
            default:
                return ""
        }
    }
}



