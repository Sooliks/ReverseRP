using System.Collections.Generic;
using System.Linq;
using GTANetworkMethods;
using NLog.Config;
using ServerSide.Database.Models.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ServerSide.Database.Handlers;

public static class GeneralHandler
{
    public static void Remove<T>(IBaseModel baseModel) where T : class
    {
        using Context db = new Context();
        var entity = db.Find<T>(baseModel.Id);
        if(entity==null)return;
        db.Remove(entity);
        db.SaveChanges();
    }
    public static async void RemoveAsync<T>(T model) where T : class
    {
        await using Context db = new Context();
        var entity = await db.FindAsync<T>(model);
        if(entity==null)return;
        db.Remove(entity);
        await db.SaveChangesAsync();
    }
    public static List<T> GetRecords<T>() where T : class
    {
        using Context db = new Context();
        IQueryable<T> records = db.Set<T>();
        return records.ToList();
    }
}