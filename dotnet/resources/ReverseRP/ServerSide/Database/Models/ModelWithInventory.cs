using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;

namespace ServerSide.Database.Models;

public abstract class ModelWithInventory<T>
{
    [NotMapped]
    private T Entity { get; set; }
    [NotMapped]
    public List<ItemBase> Inventory
    {
        get
        {
            return JsonConvert.DeserializeObject<List<ItemBase>>(InventoryJson);
        }
        set
        {
            InventoryJson = JsonConvert.SerializeObject(value);
        }
    }
    public string InventoryJson { get; set; }
    public void AddItem(ItemType itemType, int count)
    {
        using Context db = new Context();
        var searchedItem = this.Inventory.FirstOrDefault(i => i.ItemType.IdItem == itemType.IdItem);
        if (searchedItem!=null)
        {
            searchedItem.Count += count;
            db.Update(Entity);
            db.SaveChanges();
            return;
        }
        this.Inventory.Add(new ItemBase(count, itemType));
        db.Update(Entity);
        db.SaveChanges();
    }
    public void RemoveItem(ItemBase item, int count)
    {
        using Context db = new Context();
        var searchedItem = this.Inventory.FirstOrDefault(i => i.ItemType.IdItem == item.ItemType.IdItem);
        if(searchedItem==null)return;
        if ((searchedItem.Count - count) < 1)
        {
            this.Inventory.Remove(searchedItem);
            db.Update(Entity);
            db.SaveChanges();
            return;
        }
        searchedItem.Count -= count;
        db.Update(Entity);
        db.SaveChanges();
    }
    
}