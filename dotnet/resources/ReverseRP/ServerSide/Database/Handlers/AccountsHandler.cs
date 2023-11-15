
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ServerSide.Database.Models;
using ServerSide.Enums;
using ServerSide.Services.OtherServices;
using Utils;

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
        if (BCrypt.CheckPassword(password, account.Password)) return true;
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
    public static Account Register(string login, string email, string password, string ip, ulong socialClubId)
    {
        using Context db = new Context();
        string saltePassword = BCrypt.HashPassword(password, BCrypt.GenerateSalt());
        var account = new Account(login,email, saltePassword, ip, socialClubId);
        db.Account.Add(account);
        db.SaveChanges();
        return db.Account.SingleOrDefault(a => a == account);
    }
    public static Account GetAccountByLogin(string login)
    {
        using Context db = new Context();
        var account = db.Account.SingleOrDefault(a => a.Login == login);
        return account;
    }

    public static async void AddConfirmationCodeAsync(Account account, ConfirmationCodeType confirmationCodeType)
    {
        using Context db = new Context();
        var a = db.Account.Include(b => b.ConfirmationsCodes).FirstOrDefault(b => b.Id == account.Id);
        a.ConfirmationsCodes.Add(new ConfirmationCode(confirmationCodeType, AuthService.GenerateVerificationCode()));
        db.Account.Update(a);
        await db.SaveChangesAsync();
    }

    public static bool IsConfirmationCodeValid(Account account, string verificationCode, ConfirmationCodeType confirmationCodeType)
    {
        using Context db = new Context();
        var a = db.Account.Include(b => b.ConfirmationsCodes).FirstOrDefault(b => b.Id == account.Id);
        var confirmationCode =
            a.ConfirmationsCodes.FirstOrDefault(c => c.VerificationCode == verificationCode && c.Active == true && c.ConfirmationCodeType == confirmationCodeType);
        if (confirmationCode == null) return false;
        
        return true;
    }
}