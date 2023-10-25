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
        using (Context db = new Context())
        {
            var statisticOfCurrentDay = db.StatisticBusinesses.FirstOrDefault(b =>
                b.DateTime.Day == DateTime.Now.Day && b.BusinessBase.Id == businessBase.Id);
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
    }
    public static void AddBuyProduct(BusinessBase businessBase, int count = 1)
    {
        using (Context db = new Context())
        {
            var statisticOfCurrentDay = db.StatisticBusinesses.FirstOrDefault(b =>
                b.DateTime.Day == DateTime.Now.Day && b.BusinessBase.Id == businessBase.Id);
            if (statisticOfCurrentDay == null)
            {
                businessBase.StatisticBusinesses.Add(new StatisticBusiness(businessBase, DateTime.Now, count));
                db.BusinessesBase.Update(businessBase);
                db.SaveChanges();
                return;
            }

            statisticOfCurrentDay.PurchasedGoods += count;
            db.StatisticBusinesses.Update(statisticOfCurrentDay);
            db.SaveChanges();
        }
    }

    public static int GetCountVisitorsCurrentDay(BusinessBase businessBase)
    {
        using (Context db = new Context())
        {
            var statisticOfCurrentDay = db.StatisticBusinesses.FirstOrDefault(b =>
                b.DateTime.Day == DateTime.Today.Day && b.BusinessBase.Id == businessBase.Id);
            return statisticOfCurrentDay == null ? 0 : statisticOfCurrentDay.CountVisitors;
        }
    }
    public static int GetCountVisitorsMonth(BusinessBase businessBase)
    {
        using (Context db = new Context())
        {
            var business = db.BusinessesBase.Include(b => b.StatisticBusinesses)
                .FirstOrDefault(b => b.Id == businessBase.Id);
            int countVisitors = 0;
            var statisticOfMonthly = business.StatisticBusinesses.Where(b => b.DateTime.Month == DateTime.Today.Month)
                .ToList();
            foreach (var statistic in statisticOfMonthly)
            {
                countVisitors += statistic.CountVisitors;
            }

            return countVisitors;
        }
    }

    public static List<StatisticList> GetCountVisitorsAllDays(BusinessBase businessBase)
    {
        using (Context db = new Context())
        {

            var business = db.BusinessesBase.Include(b => b.StatisticBusinesses)
                .FirstOrDefault(b => b.Id == businessBase.Id);

            return business.StatisticBusinesses.Where(s=>s.DateTime.Month == DateTime.Now.Month).Select(s => new StatisticList()
            {
                DateTime = $"{s.DateTime.Day}.{s.DateTime.Month}", CountVisitors = s.CountVisitors,
                PurchasedGoods = s.PurchasedGoods
            }).ToList();
        }
    }
}

public record StatisticList
{
    public string DateTime { get; set; }
    public int CountVisitors { get; set; }
    public int PurchasedGoods { get; set; }
}