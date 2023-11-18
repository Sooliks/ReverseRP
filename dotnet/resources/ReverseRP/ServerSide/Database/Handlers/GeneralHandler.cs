using GTANetworkMethods;
using Task = System.Threading.Tasks.Task;

namespace ServerSide.Database.Handlers;

public class GeneralHandler
{
    public static void Remove(object model)
    {
        using Context db = new Context();
        db.Remove(model);
        db.SaveChanges();
    }
    public static async Task RemoveAsync<T>(T model)
    {
        await using Context db = new Context();
        db.Remove(model);
        await db.SaveChangesAsync();
    }
}