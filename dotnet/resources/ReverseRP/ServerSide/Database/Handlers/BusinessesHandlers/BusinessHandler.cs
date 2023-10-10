using System.Linq;
using NLog.Config;
using ServerSide.Database.Models;

namespace ServerSide.Database.Handlers;

public class BusinessHandler
{
    public static void AddMoneyInBank(int countMoney, int businessId)
    {
        using Context db = new Context();
        var business = db.BusinessesBase.FirstOrDefault(b=>b.Id == businessId);
        business.Bank += countMoney;
        db.BusinessesBase.Update(business);
        db.SaveChanges();
    }
}