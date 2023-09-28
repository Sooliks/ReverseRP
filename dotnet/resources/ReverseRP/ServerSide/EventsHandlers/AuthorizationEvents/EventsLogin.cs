using System;
using System.Linq;
using GTANetworkAPI;
using Newtonsoft.Json;
using ServerSide.Database.Handlers;
using ServerSide.Extensions;
using ServerSide.Services;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ServerSide.EventsHandlers.Authorization;

public class EventsLogin : Script
{
    [RemoteEvent("CEF::SERVER::ON_FINISH_LOGIN")]
    public async void OnFinishLogin(Player player, string login, string password, bool remember)
    {
        var account = AccountsHandler.GetAccountBySocialClubId(Convert.ToInt64(player.SocialClubId));
        if (account != null)
        {
            if (account.IsBanned)
            {
                player.TriggerCefEvent("SERVER::CEF::ERROR_LOGIN","Ваш аккаунт в бане");
                return;
            }
        }
        if (AccountsHandler.IsLoginExist(login) && AccountsHandler.IsPasswordValid(login, password))
        {
            var _account = AccountsHandler.GetAccountByLogin(login);
            player.SetAccount(_account);
            player.ChangeCefWindow(CefWindowsPaths.SelectCharacters);
            var list = CharacterHandler.GetCharactersByAccount(_account);
            var newList = list.Select(c => new
            {
                Id = c.Id, FirstName = c.FirstName, LastName = c.LastName, Lvl = c.Lvl, Money = c.Money,
                MoneyBank = c.MoneyBank
            }).ToList();
            player.TriggerCefEvent("SERVER::CEF::ADD_CHARACTERS_LIST",newList);
        }
        else
        {
            player.TriggerCefEvent("SERVER::CEF::ERROR_LOGIN","Неверный логин или пароль");
        }
    }
}