using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ServerSide.Database.Models;

namespace ServerSide.Database.Handlers;

public class StatisticBusinessHandler
{
    public static void AddVisitor(BusinessBase businessBase)
    {
        using Context db = new Context();
        var statisticOfCurrentDay = db.StatisticBusinesses.FirstOrDefault(b => b.DateTime.Day == DateTime.Now.Day && b.BusinessBase.Id == businessBase.Id);
        if (statisticOfCurrentDay == null)
        {
            businessBase.StatisticBusinesses.Add(new StatisticBusiness(businessBase, DateTime.Now));
            db.BusinessesBase.Update(businessBase);
            db.SaveChanges();
            return;
        }

        statisticOfCurrentDay.CountVisitors += 1;
        db.StatisticBusinesses.Update(statisticOfCurrentDay);
        db.SaveChanges();
    }

    public static int GetCountVisitorsCurrentDay(BusinessBase businessBase)
    {
        using Context db = new Context();
        var statisticOfCurrentDay = db.StatisticBusinesses.FirstOrDefault(b => b.DateTime.Day == DateTime.Today.Day && b.BusinessBase.Id == businessBase.Id);
        return statisticOfCurrentDay.CountVisitors;
    }

    public static List<StatisticList> GetCountVisitorsAllDays(BusinessBase businessBase)
    {
        using Context db = new Context();
        var business = db.BusinessesBase.Include(b => b.StatisticBusinesses)
            .FirstOrDefault(b => b.Id == businessBase.Id);
        
        return business.StatisticBusinesses.Select(s => new StatisticList() { DateTime = s.DateTime, CountVisitors = s.CountVisitors }).ToList();
    }
    
}

public record StatisticList
{
    public DateTime DateTime { get; set; }
    public int CountVisitors { get; set; }
}