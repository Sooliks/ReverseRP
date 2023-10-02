using System.Linq;
using ServerSide.Database.Models;

namespace ServerSide.Database.Handlers;

public class ItemHandler
{
    public static Item GetItemByIdItem(int idItem)
    {
        using Context db = new Context();
        return db.Items.FirstOrDefault(i => i.IdItem == idItem);
    }
}