using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ServerSide.Database.Models;

namespace ServerSide.Database.Handlers;

public static class AccountsHandler
{
    public static bool IsLoginExist(string login)
    {
        using Context db = new Context();
        return db.Account.SingleOrDefault(a => a.Login == login) != null;
    }

    public static bool IsEmailExist(string email)
    {
        using Context db = new Context();
        return db.Account.SingleOrDefault(a => a.Email == email) != null;
    }
    public static bool IsPasswordValid(string login, string password)
    {
        using Context db = new Context();
        var account = db.Account.SingleOrDefault(a => a.Login == login);
        if (Bcrypt.BCrypt.CheckPassword(password, account.Password)) return true;
        return false;
    }

    public static Account GetAccountBySocialClubId(long socialClubId)
    {
        using Context db = new Context();
        var account = db.Account.FirstOrDefault(a => a.SocialClubId == socialClubId);
        if (account != null)
        {
            return account;
        }
        return null;
    }
    public static void Register(string login, string email, string password, string ip, ulong socialClubId)
    {
        using Context db = new Context();
        string saltePassword = Bcrypt.BCrypt.HashPassword(password, Bcrypt.BCrypt.GenerateSalt());
        var account = new Account(login,email, saltePassword, ip, socialClubId);
        db.Account.Add(account);
        db.SaveChanges();
    }
}