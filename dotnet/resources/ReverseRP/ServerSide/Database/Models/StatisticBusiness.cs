using System;
using ServerSide.Data;

namespace ServerSide.Database.Models;

public class StatisticBusiness
{
    public int Id { get; set; }
    public BusinessBase? BusinessBase { get; set; }
    public DateTime DateTime { get; set; }
    public int CountVisitors { get; set; }
    public int PurchasedGoods { get; set; }

    public StatisticBusiness()
    {
        
    }

    public StatisticBusiness(BusinessBase businessBase, DateTime dateTime)
    {
        BusinessBase = businessBase;
        DateTime = dateTime;
        CountVisitors = 1;
        PurchasedGoods = 0;
    }
}