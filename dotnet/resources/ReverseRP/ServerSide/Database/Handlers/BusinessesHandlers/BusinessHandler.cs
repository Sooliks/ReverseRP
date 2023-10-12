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
        using Context db = new Context();
        var business = db.BusinessesBase.FirstOrDefault(b=>b.Id == businessId);
        business.Bank += countMoney;
        db.BusinessesBase.Update(business);
        db.SaveChanges();
    }
    public static BusinessBase GetBusinessById(int idBusiness)
    {
        using Context db = new Context();
        return db.BusinessesBase.FirstOrDefault(b=>b.Id == idBusiness);
    }

    public static void SetOwnerCharacterBusiness(Character character, int businessId)
    {
        using Context db = new Context();
        var business = db.BusinessesBase.FirstOrDefault(b=>b.Id == businessId);
        business.OwnerCharacter = character;
        db.BusinessesBase.Update(business);
        db.SaveChanges();
    }

    public static bool IsCharacterOwnerBusiness(Character character, int businessId)
    {
        if (character == null) return false;
        using Context db = new Context();
        var business = db.BusinessesBase.Include(b=>b.OwnerCharacter).FirstOrDefault(b=>b.Id == businessId);
        if (business == null) return false;
        if (business.OwnerCharacter != null && business.OwnerCharacter.Id == character.Id)
        {
            return true;
        }

        return false;
    }

    public static List<BusinessBase> GetAllBusinesses()
    {
        using Context db = new Context();
        return db.BusinessesBase.ToList();
    }
}