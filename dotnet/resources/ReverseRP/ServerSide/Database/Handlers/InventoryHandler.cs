using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using ServerSide.Database.Models;

namespace ServerSide.Database.Handlers;

public class InventoryHandler
{
    public static void AddItem(Character character,ItemType itemType, int count)
    {
        using Context db = new Context();
        character = db.Character.SingleOrDefault(c => c == character);
        db.Entry(character).Collection(c=>c.Inventory).Load();
        var searchedItem = db.ItemBase.Include(i => i.ItemType).Include(i=>i.Character).FirstOrDefault(i => i.Character.Id == character.Id && i.ItemType.IdItem == itemType.IdItem);
        if (searchedItem!=null)
        {
            searchedItem.Count += count;
            db.Character.Update(character);
            db.SaveChanges();
            return;
        }
        character.Inventory.Add(new ItemBase(count, itemType));
        db.Character.Update(character);
        db.SaveChanges();
    }
    public static List<ItemBase> GetInventory(Character character)
    {
        using Context db = new Context();
        return db.ItemBase.Include(i=> i.Character).Include(i=>i.ItemType).Where(i => i.Character.Id == character.Id).ToList();
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