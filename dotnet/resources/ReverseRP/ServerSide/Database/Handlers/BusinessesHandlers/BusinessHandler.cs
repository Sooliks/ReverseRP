using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NLog.Config;
using ServerSide.Database.Models;

namespace ServerSide.Database.Handlers;

public class BusinessHandler
{
    public static void AddMoneyInBank(int countMoney, int businessId)
    {
        using (Context db = new Context())
        {
            var business = db.BusinessesBase.FirstOrDefault(b => b.Id == businessId);
            business.Bank += countMoney;
            db.BusinessesBase.Update(business);
            db.SaveChanges();
        }
    }
    public static BusinessBase GetBusinessById(int idBusiness)
    {
        using (Context db = new Context())
        {
            return db.BusinessesBase.FirstOrDefault(b => b.Id == idBusiness);
        }
    }

    public static void SetOwnerCharacterBusiness(Character character, int businessId)
    {
        using (Context db = new Context())
        {
            var business = db.BusinessesBase.FirstOrDefault(b => b.Id == businessId);
            business.OwnerCharacterId = character.Id;
            db.BusinessesBase.Update(business);
            db.SaveChanges();
        }
    }

    public static bool IsCharacterOwnerBusiness(Character character, BusinessBase business)
    {
        if (character == null) return false;
        if (business == null) return false;
        if (business.OwnerCharacterId != 0 && business.OwnerCharacterId == character.Id)
        {
            return true;
        }
        return false;
    }

    public static List<BusinessBase> GetAllBusinesses()
    {
        using (Context db = new Context())
        {
            return db.BusinessesBase.ToList();
        }
    }

    public static void MinusMoneyBank(BusinessBase businessBase, int countMoney)
    {
        using (Context db = new Context())
        {
            businessBase.Bank -= countMoney;
            db.BusinessesBase.Update(businessBase);
            db.SaveChanges();
        }
    }
    public static void RemoveItem(ItemBusiness itemBusiness, BusinessBase business, int count = 1)
    {
        using Context db = new Context();
        var newListItems = business.Items;
        int index = business.Items.FindIndex(s => s.ItemId == itemBusiness.ItemId);
        itemBusiness.Count -= count;
        newListItems[index] = itemBusiness;
        business.Items = newListItems;
        db.BusinessesBase.Update(business);
        db.SaveChanges();
    }
}