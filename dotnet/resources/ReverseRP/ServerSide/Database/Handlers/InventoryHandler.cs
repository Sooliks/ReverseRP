using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using ServerSide.Database.Models;

namespace ServerSide.Database.Handlers;

public class InventoryHandler
{
    public static void AddItem(Character character,ItemBase item)
    {
        using Context db = new Context();
        character = db.Character.SingleOrDefault(c => c == character);
        db.Entry(character).Collection(c=>c.Inventory).Load();
        var searchedItem = character.Inventory.FirstOrDefault(i => i.IdItem == item.IdItem);
        if (searchedItem!=null)
        {
            int index = character.Inventory.FindIndex(i=>i==searchedItem);
            searchedItem.Count += 1;
            character.Inventory[index] = searchedItem;
            db.Character.Update(character);
            db.SaveChanges();
            return;
        }
        character.Inventory.Add(item);
        db.Character.Update(character);
        db.SaveChanges();
    }
    public static List<ItemBase> GetInventory(Character character)
    {
        using Context db = new Context();
        return db.ItemBase.Where(i => i.Character.Id == character.Id).ToList();
    }
    public static void RemoveItem(Character character,ItemBase item)
    {
        using Context db = new Context();
        character = db.Character.SingleOrDefault(c => c == character);
        db.Entry(character).Collection(c=>c.Inventory).Load();
        character.Inventory.Remove(item);
        db.Character.Update(character);
        db.SaveChanges();
    }
    
}