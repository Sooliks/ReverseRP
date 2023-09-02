using System.Collections.Generic;
using ServerSide.Database.Handlers;
using ServerSide.Database.Models;

namespace ServerSide.Database.Extensions;

public static class CharacterExtensions
{
    public static List<ItemBase> GetInventory(this Character character) => InventoryHandler.GetInventory(character);
    public static void AddItem(this Character character, ItemBase item) => InventoryHandler.AddItem(character, item);
    public static void RemoveItem(this Character character, ItemBase item) => InventoryHandler.RemoveItem(character, item);
}