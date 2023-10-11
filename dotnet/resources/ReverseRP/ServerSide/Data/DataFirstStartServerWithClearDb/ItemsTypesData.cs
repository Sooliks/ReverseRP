using System.Collections.Generic;
using ServerSide.Database.Models;
using ServerSide.Inventory.Items;

namespace ServerSide.Data;

public class ItemsTypesData
{
    public static readonly List<ItemType> ItemTypesDefault = new List<ItemType>()
    {
        new Food("Бургер", "Восполняет 70 сытости",759729215,0,70),
        new Food("Пицца", "Восполняет 80 сытости",759729215,1,80)
    };
}