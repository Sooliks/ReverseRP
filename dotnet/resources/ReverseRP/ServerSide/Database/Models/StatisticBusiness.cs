using System;
using ServerSide.Data;
using ServerSide.Database.Models.Interfaces;

namespace ServerSide.Database.Models;

public class StatisticBusiness : BaseModel
{
    public BusinessBase? BusinessBase { get; set; }
    public DateTime DateTime { get; set; }
    public int CountVisitors { get; set; }
    public int PurchasedGoods { get; set; }

    public StatisticBusiness()
    {
        
    }

    public StatisticBusiness(BusinessBase businessBase, DateTime dateTime, int count = 0)
    {
        BusinessBase = businessBase;
        DateTime = dateTime;
        CountVisitors = 1;
        PurchasedGoods = count;
    }
}