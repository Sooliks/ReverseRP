using GTANetworkMethods;
using Task = System.Threading.Tasks.Task;

namespace ServerSide.Database.Handlers;

public class GeneralHandler
{
    public static void Remove<T>(T model)
    {
        using Context db = new Context();
        db.Remove(model);
        db.SaveChanges();
    }
    public static Task RemoveAsync<T>(T model)
    {
        using Context db = new Context();
        db.Remove(model);
        db.SaveChangesAsync();
        return Task.CompletedTask;
    }
}