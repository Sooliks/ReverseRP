using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerSide.Database.Models;

public class Account
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Ip { get; set; }
    public long SocialClubId { get; set; }
    public bool IsBanned { get; set; }
    public List<Character> Characters { get; set; }




    public Account()
    {
        
    }

    public Account(string login, string email, string password, string ip, ulong socialClubId)
    {
        this.Login = login;
        this.Email = email;
        this.Password = password;
        this.Ip = ip;
        this.SocialClubId = Convert.ToInt64(socialClubId);
        this.IsBanned = false;
        this.Characters = new List<Character>();
    }
}